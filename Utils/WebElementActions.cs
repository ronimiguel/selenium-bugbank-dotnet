using BugBankSelenium.Pages;
using OpenQA.Selenium;

namespace BugBankSelenium.Utils;

public class WebElementActions : Locators
{
  protected IWebDriver driver;

  public WebElementActions(IWebDriver driver)
  {
    this.driver = driver;
  }

  public void AbrirNavegador(string url)
  {
    if (driver != null)
    {
      driver.Navigate().GoToUrl(url);
    }
  }

  public void FecharNavegador()
  {
    driver.Quit();
  }

  public void Clicar(By elemento)
  {
    IWebElement webElement = driver.FindElement(elemento);
    if (webElement != null)
    {
      webElement.Click();
    }
  }

  public void Escrever(By elemento, string? texto)
  {
    IWebElement webElement = driver.FindElement(elemento);
    if (webElement != null && texto != null)
    {
      webElement.Clear();
      webElement.SendKeys(texto);
    }
  }

  public void ClicarComJS(By elemento)
  {
    IWebElement webElement = driver.FindElement(elemento);
    if (webElement != null)
    {
      IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
      jsExecutor.ExecuteScript("arguments[0].click();", webElement);
    }
  }

  public void HighlightElement(IWebElement element, string color)
  {
    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
    js.ExecuteScript("arguments[0].setAttribute('style', 'border: 8px solid " + color + ";');", element);
  }

  public string ExtrairInnerText(By elemento)
  {
    IWebElement texto = driver.FindElement(elemento);
    return texto.GetAttribute("innerText") ?? string.Empty;
  }
}