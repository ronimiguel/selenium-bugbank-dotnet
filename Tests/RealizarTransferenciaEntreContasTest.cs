using AventStack.ExtentReports.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using BugBankSelenium.Utils;
using BugBankSelenium.Pages;
using AventStack.ExtentReports;
using System;

namespace BugBankSelenium.Tests;
[TestFixture]
public class RealizarTransferenciaEntreContasTest
{
  private IWebDriver? driver;
  private HomePage homePage = null!;
  private TransferenciaPage transferenciaPage = null!;

  ExtratoPage extratoPage = null!;
  readonly GerarDadosClientes gerar = new();
  [SetUp]
  public void SetUp()
  {
    driver = DriverFactory.GetDriver();
    string url = "https://bugbank.netlify.app/";
    homePage = new HomePage(driver);
    transferenciaPage = new TransferenciaPage(driver);
    extratoPage = new ExtratoPage(driver);
    RelatorioFactory.NomeDoRelatorio("Relatório de Testes BugBank");
    RelatorioFactory.NovoRelatorio();

    homePage.AbrirNavegador(url);
  }

  [TearDown]
  public void TearDown()
  {
    DriverFactory.QuitDriver();
    Relatorio.Close();
  }

  [Test]
  public void RealizarTransferenciaEntreContasComConsultaNoExtrato()
  {
    try
    {
      Relatorio.CreateTest("Realizar transferência entre contas com saldo com consulta no extrato.");
      // Variaveis para gerar clientes, valor e descricao para transferência
      Cliente CLIENTE_PARA_CREDITAR = gerar.NovoCliente();
      Cliente CLIENTE_PARA_DEBITAR = gerar.NovoCliente();
      decimal VALOR_DA_TRANSFERENCIA = gerar.ValorTransferencia();
      string DESCRICAO_DA_TRANSFERENCIA = gerar.DescricaoTransferencia();

      Relatorio.CreateStep("Registrar conta com saldo para receber valor via transferência");
      homePage.RegistrarContaComSaldo(CLIENTE_PARA_CREDITAR);
      homePage.AcessarConta(CLIENTE_PARA_CREDITAR);
      Assert.IsTrue(CLIENTE_PARA_CREDITAR.PossuiConta);
      homePage.AtualizarSaldoInicialCliente(CLIENTE_PARA_CREDITAR);
      homePage.SairDaConta();

      Relatorio.CreateStep("Registrar conta com saldo para enviar valor");
      homePage.RegistrarContaComSaldo(CLIENTE_PARA_DEBITAR);
      homePage.AcessarConta(CLIENTE_PARA_DEBITAR);
      Assert.IsTrue(CLIENTE_PARA_DEBITAR.PossuiConta);
      homePage.AtualizarSaldoInicialCliente(CLIENTE_PARA_DEBITAR);

      Relatorio.CreateStep("Realizar transferência da conta debitar para a conta creditar");
      homePage.Transferencia();
      transferenciaPage.RealizarTransferencia(CLIENTE_PARA_CREDITAR, VALOR_DA_TRANSFERENCIA, DESCRICAO_DA_TRANSFERENCIA);
      transferenciaPage.ClicarBotaoFechar();
      transferenciaPage.ClicarBotaoVoltar();

      Relatorio.CreateStep("Atualizar saldo atual e verificar subtração do valor da transferência");
      homePage.AtualizarSaldoAtualCliente(CLIENTE_PARA_DEBITAR);
      Assert.AreEqual(CLIENTE_PARA_DEBITAR.SaldoAtual, CLIENTE_PARA_DEBITAR.SaldoInicial - VALOR_DA_TRANSFERENCIA);
      homePage.SairDaConta();

      Relatorio.CreateStep("Acessar conta creditada e verificar recebimento do valor da transferência");
      homePage.AcessarConta(CLIENTE_PARA_CREDITAR);
      homePage.AtualizarSaldoAtualCliente(CLIENTE_PARA_CREDITAR);
      Assert.AreEqual(CLIENTE_PARA_CREDITAR.SaldoAtual, CLIENTE_PARA_CREDITAR.SaldoInicial + VALOR_DA_TRANSFERENCIA);

      Relatorio.CreateStep("Consultar no extrato descrição e valor da transferencia");
      homePage.clicarBotaoExtrato();
      Assert.AreEqual(DESCRICAO_DA_TRANSFERENCIA, extratoPage.ConsultarDescricaoTransferenciaNoExtrato(DESCRICAO_DA_TRANSFERENCIA));
      Assert.AreEqual(VALOR_DA_TRANSFERENCIA.ToString(), extratoPage.ConsultarValorTransferenciaNoExtrato(DESCRICAO_DA_TRANSFERENCIA));
      extratoPage.ClicarVoltar();
      homePage.SairDaConta();
    }
    catch (Exception ex)
    {
      Relatorio.Log(Status.Fail, "Falha no teste." + ex.Message);
      throw;
    }
  }
}
