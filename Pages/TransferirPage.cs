using OpenQA.Selenium;
using BugBankSelenium.Utils;
using AventStack.ExtentReports;

namespace BugBankSelenium.Pages;
public class TransferenciaPage : WebElementActions
{

  readonly ScreenshotHelper screenshot;
  public TransferenciaPage(IWebDriver driver) : base(driver)
  {
    screenshot = new ScreenshotHelper(driver);
  }

  public void PreencherNumeroDaConta(Cliente cliente)
  {
    if (cliente.NumeroConta != null)
    {
      Escrever(TRANSFERENCIA_NUM_CONTA_INPUT, cliente.NumeroConta);
    }
  }
  public void PreencherNumeroDoDigito(Cliente cliente)
  {
    if (cliente.NumeroDigito != null)
    {
      Escrever(TRANSFERENCIA_NUM_DIGITO_INPUT, cliente.NumeroDigito);
    }
  }

  public void PreencherValorDaTransferencia(decimal valorTransferencia)
  {
    Escrever(TRANSFERENCIA_VALOR_INPUT, valorTransferencia.ToString());
  }

  public void PreencherDescricaoTransferencia(string descricao)
  {
    Escrever(TRANSFERENCIA_DESCRICAO_INPUT, descricao);
  }

  public void ClicarBotaoTransferirAgora()
  {
    Clicar(TRANSFERENCIA_TRANSFERIR_AGORA_BTN);
  }

  public string ExtrairTextoMensagemModal()
  {
    string texto = ExtrairInnerText(TRANSFERENCIA_MSG_TRANSFERENCIA_TXT);
    return texto ?? string.Empty;
  }

  public void ClicarBotaoFechar()
  {
    Clicar(FECHAR_BTN);
  }

  public void ClicarBotaoVoltar()
  {
    Clicar(VOLTAR_BTN);
  }

  public void RealizarTransferencia(Cliente cliente, decimal valorTransferencia, string descricao)
  {
    Relatorio.Log(Status.Info, "Realizar transfência no valor de R$ " + valorTransferencia.ToString() + " para cliente " + cliente.Nome + " - Conta: " + cliente.NumeroConta + " Digito: " + cliente.NumeroDigito);
    PreencherNumeroDaConta(cliente);
    PreencherNumeroDoDigito(cliente);
    PreencherValorDaTransferencia(valorTransferencia);
    PreencherDescricaoTransferencia(descricao);
    ClicarBotaoTransferirAgora();
    Relatorio.Log(Status.Pass, "Transferência no valor de R$ " + valorTransferencia.ToString() + " realizada com sucesso.", screenshot.CapturarTela());
  }
}