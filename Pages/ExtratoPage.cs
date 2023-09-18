using OpenQA.Selenium;
using BugBankSelenium.Utils;
using AventStack.ExtentReports;

namespace BugBankSelenium.Pages;
public class ExtratoPage : WebElementActions
{
  readonly ContaUtils contaUtils;
  readonly ScreenshotHelper screenshot;
  

  public ExtratoPage(IWebDriver driver) : base(driver)
  {
    contaUtils = new ContaUtils(driver);
    screenshot = new ScreenshotHelper(driver);
  }

  public void ClicarVoltar()
  {
    Clicar(VOLTAR_BTN);
  }

  public string ConsultarDescricaoTransferenciaNoExtrato(string descricao)
  {
    Relatorio.Log(Status.Info, "Consultar descrição da transferência no extrato.");
    string consultarDescricao = contaUtils.ConsultarDescricaoTransferenciaNoExtrato(descricao);
    Relatorio.Log(Status.Pass, "Descrição ( " + descricao + " ) encontrada com sucesso no extrato.", screenshot.CapturarTela());
    return consultarDescricao ?? "Descricao não encontrada.";
  }

  public string ConsultarValorTransferenciaNoExtrato(string descricao)
  {
    Relatorio.Log(Status.Info, "Consultar valor da transferência no extrato.");
    Relatorio.Log(Status.Pass, "Valor ( R$ " + contaUtils.ConsultarExtrairValorTransferenciaNoExtrato(descricao) + " ) encontrado com sucesso no extrato.", screenshot.CapturarTela());
    return contaUtils.ConsultarExtrairValorTransferenciaNoExtrato(descricao) ?? "Valor não encontrado.";
  }
}