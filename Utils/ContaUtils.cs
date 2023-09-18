using BugBankSelenium.Pages;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace BugBankSelenium.Utils;
public class ContaUtils : Locators
{
  private readonly IWebDriver driver;

  public ContaUtils(IWebDriver driver)
  {
    this.driver = driver;
  }
  public string ExtrairTextoMensagemComDadosDaConta(By elemento)
  {
    return driver.FindElement(elemento).GetAttribute("innerText");
  }

  public static string[]? ExtrairContaEDigito(string mensagem)
  {
    string padraoTexto = "A conta (\\d{1,3})-(\\d+) foi criada com sucesso";
    Match padraoEncontrado = Regex.Match(mensagem, padraoTexto);

    if (padraoEncontrado.Success)
    {
      string[] resultado = new string[2];
      resultado[0] = padraoEncontrado.Groups[1].Value;
      resultado[1] = padraoEncontrado.Groups[2].Value;
      return resultado;
    }
    return null;
  }

  public static void SalvarContaEDigitoCliente(Cliente cliente, string[] dadosContaEDigito)
  {
    cliente.NumeroConta = dadosContaEDigito[0];
    cliente.NumeroDigito = dadosContaEDigito[1];
  }

  public static void MarcarContaExistente(Cliente cliente)
  {
    cliente.PossuiConta = true;
  }

  public void ExtrairESalvarDadosContaCliente(Cliente cliente, By mensagemTextoComDados)
  {
    string mensagemComDados = ExtrairTextoMensagemComDadosDaConta(mensagemTextoComDados);
    string[]? dadosConta = ExtrairContaEDigito(mensagemComDados);
    if (dadosConta != null)
    {
            SalvarContaEDigitoCliente(cliente, dadosConta);
    }
        MarcarContaExistente(cliente);
  }

  public void HighLightText(IWebElement element)
  {
    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
    js.ExecuteScript("arguments[0].setAttribute('style', 'border: 8px solid " + "green" + ";');", element);
  }
  public decimal ConsultarSaldo(IWebDriver driver)
  {
    IWebElement saldo = driver.FindElement(By.Id("textBalance"));
    HighLightText(saldo);
    string dadosSaldo = saldo.Text;
    int indiceDoCifrao = dadosSaldo.IndexOf("$");

    // +2 é usado para pular o caractere '$' e o espaço em branco
    string saldoAtualNumerico = dadosSaldo.Substring(indiceDoCifrao + 2);

    // Alterar formato brasileiro de moeda para padrão numérico com ponto
    string saldoAtualComPonto = saldoAtualNumerico.Replace(".", ""); // Remove pontos
    string saldoAtualLimpo = Regex.Replace(saldoAtualComPonto, @"[^0-9.,]", ""); // Remove caracteres não numéricos

    // Saldo final em decimal para valores monetários
    decimal saldoAtual = decimal.Parse(saldoAtualLimpo.Replace(",", ".")); // Converte para decimal

    return saldoAtual;
  }
  public void AtualizarSaldoInicial(Cliente cliente)
  {
    decimal saldoInicial = ConsultarSaldo(driver);
    cliente.SaldoInicial = saldoInicial;
  }

  public void AtualizarSaldoAtual(Cliente cliente)
  {
    decimal saldoAtual = ConsultarSaldo(driver);
    cliente.SaldoAtual = saldoAtual;
  }

  public string ConsultarDescricaoTransferenciaNoExtrato(string descricao)
  {
    IWebElement descricaoAProcurar = driver.FindElement(By.XPath("//p[@id = 'textDescription' and text() ='" + descricao + "']"));
    string textoDescricaoEncontrado = descricaoAProcurar.GetAttribute("innerText");
    HighLightText(descricaoAProcurar);
    return textoDescricaoEncontrado;
  }

  public string? ConsultarExtrairValorTransferenciaNoExtrato(string descricao)
  {
    IWebElement descricaoAProcurar = driver.FindElement(By.XPath("//p[@id = 'textDescription' and text() ='" + descricao + "']/following-sibling::p"));
    HighLightText(descricaoAProcurar);
    string textoDescricaoEncontrado = descricaoAProcurar.GetAttribute("innerText");

    // Remove todos os caracteres exceto dígitos, vírgula e ponto
    string textoLimpo = Regex.Replace(textoDescricaoEncontrado, @"[^\d,.]", "");
    textoLimpo = textoLimpo.Replace(",", "."); // Substitui ',' por '.' para formar o valor correto

    return string.IsNullOrEmpty(textoLimpo) ? null : textoLimpo;
  }
}