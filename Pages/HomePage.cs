using OpenQA.Selenium;
using BugBankSelenium.Utils;
using AventStack.ExtentReports;

namespace BugBankSelenium.Pages;
public class HomePage : WebElementActions
{
  readonly ContaUtils contaUtils;
  readonly ScreenshotHelper screenshot;
  public HomePage(IWebDriver driver) : base(driver)
  {
    contaUtils = new ContaUtils(driver);
    screenshot = new ScreenshotHelper(driver);
  }

  private void ClicarBotaoCadastrar()
  {
    Clicar(REGISTRAR_CADASTRAR_BTN);
  }

  private void ClicarBotaoCriarContaComSaldo()
  {
    ClicarComJS(REGISTRAR_CRIAR_CONTA_COM_SALDO_BTN);
  }

  private void InformarConfirmarSenha(Cliente cliente)
  {
    Escrever(REGISTRAR_CONFIRMAR_SENHA_INPUT, cliente.ConfirmarSenha);
  }

  private void InformarSenhaRegistrar(Cliente cliente)
  {
    Escrever(REGISTRAR_SENHA_INPUT, cliente.Senha);
  }

  private void InformarNomeRegistrar(Cliente cliente)
  {
    Escrever(REGISTRAR_NOME_INPUT, cliente.Nome);
  }

  private void InformarEmailRegistrar(Cliente cliente)
  {
    Escrever(REGISTRAR_EMAIL_INPUT, cliente.Email);
  }

  private void ClicarBotaoRegistrar()
  {
    Clicar(REGISTRAR_BTN);
  }

  private void InformarSenhaAcessarConta(Cliente cliente)
  {
    Escrever(ACESSAR_SENHA_INPUT, cliente.Senha);
  }

  private void InformarEmailAcessarConta(Cliente cliente)
  {
    Escrever(ACESSAR_EMAIL_INPUT, cliente.Email);
  }

  private void ClicarBotaoAcessar()
  {
    Clicar(ACESSAR_BTN);
  }

  private void ClicarBotaoFechar()
  {
    ClicarComJS(FECHAR_BTN);
  }

  public void Transferencia()
  {
    Clicar(TRANSFERENCIA_BTN);
  }

  public void clicarBotaoExtrato()
  {
    Clicar(EXTRATO_BTN);
  }

  public void AtualizarSaldoInicialCliente(Cliente cliente)
  {
    Relatorio.Log(Status.Info, "Atualizar saldo inicial de " + cliente.Nome);
    contaUtils.AtualizarSaldoInicial(cliente);
    Relatorio.Log(Status.Pass, "SALDO INICIAL: R$ " + cliente.SaldoInicial.ToString(), screenshot.CapturarTela());
  }

  public void AtualizarSaldoAtualCliente(Cliente cliente)
  {
    Relatorio.Log(Status.Info, "Atualizar saldo atual de " + cliente.Nome);
    contaUtils.AtualizarSaldoAtual(cliente);
    Relatorio.Log(Status.Pass, "SALDO ATUAL: R$ " + cliente.SaldoAtual.ToString(), screenshot.CapturarTela());
  }
  public void SairDaConta()
  {
    Clicar(SAIR_BTN);
  }
  public void RegistrarContaComSaldo(Cliente cliente)
  {
    Relatorio.Log(Status.Info, "Cadastrar nova conta com os dados - Nome: " + cliente.Nome + ", email: " + cliente.Email + ", Senha: " + cliente.Senha);
    ClicarBotaoRegistrar();
    InformarEmailRegistrar(cliente);
    InformarNomeRegistrar(cliente);
    InformarSenhaRegistrar(cliente);
    InformarConfirmarSenha(cliente);
    ClicarBotaoCriarContaComSaldo();
    ClicarBotaoCadastrar();
    contaUtils.ExtrairESalvarDadosContaCliente(cliente, REGISTRAR_MSG_CADASTRO_TXT);
    Relatorio.Log(Status.Pass, "Conta cadastrada com sucesso - " + " Conta: " + cliente.NumeroConta + " Digito: " + cliente.NumeroDigito, screenshot.CapturarTela());
    ClicarBotaoFechar();
  }
  public void AcessarConta(Cliente cliente)
  {
    Relatorio.Log(Status.Info, "Acessar conta de " + cliente.Nome);
    InformarEmailAcessarConta(cliente);
    InformarSenhaAcessarConta(cliente);
    ClicarBotaoAcessar();
    Relatorio.Log(Status.Pass, "Conta acessada com sucesso.", screenshot.CapturarTela());
  }
}
