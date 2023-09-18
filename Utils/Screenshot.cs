using OpenQA.Selenium;
using System;
using System.Threading.Tasks;


namespace BugBankSelenium.Utils;
public class ScreenshotHelper
{
    protected IWebDriver driver;

    public ScreenshotHelper(IWebDriver driver)
    {
        this.driver = driver; 
    }

    public string CapturarTela()
    {
        try
        {
            Task.Delay(200).Wait(); // tempo para aguardar os efeitos da pagina antes de capturar screenshot
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao capturar a screenshot: {e.Message}");
            return string.Empty;
        }
    }
}