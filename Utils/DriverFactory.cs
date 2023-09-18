using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BugBankSelenium.Utils;
public class DriverFactory
{
  private static IWebDriver? driver;

  public static IWebDriver GetDriver()
  {
    if (driver == null)
    {
      // Configurar o driver do Chrome
      ChromeOptions options = new ChromeOptions();
      options.AddArgument("--start-maximized"); // Maximiza a janela do navegador
      options.AddArgument("--disable-extensions"); // Desativa extensões do Chrome (opcional)
      driver = new ChromeDriver(options);
      driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);


    }
    return driver;
  }

  public static void QuitDriver()
  {
    if (driver != null)
    {
      // Fechar o driver
      driver.Quit();
      driver = null;
    }
  }
}
