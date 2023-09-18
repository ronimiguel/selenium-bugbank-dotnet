using AventStack.ExtentReports;
using System;
using System.Threading;

namespace BugBankSelenium.Utils
{
  public class Relatorio
  {
    private static readonly ExtentReports extent = RelatorioFactory.GetInstance() ?? new ExtentReports();
    private static readonly ThreadLocal<ExtentTest> parentTest = new ThreadLocal<ExtentTest>() ?? new ThreadLocal<ExtentTest>();
    private static readonly ThreadLocal<ExtentTest> test = new ThreadLocal<ExtentTest>() ?? new ThreadLocal<ExtentTest>();

    public static void CreateTest(string testName)
    {
      ExtentTest extentTest = extent.CreateTest(testName);
      parentTest.Value = extentTest;
    }

    public static void CreateStep(string stepName)
    {
      try
      {
        ExtentTest child = (parentTest.Value ?? extent.CreateTest(stepName)).CreateNode(stepName);
        test.Value = child;
      }
      catch (NullReferenceException e)
      {
        Console.WriteLine(e.StackTrace);
      }
    }

    public static void Log(Status status, string message)
    {
      if (ExistInstance())
      {
        return;
      }
      test.Value?.Log(status, message);
    }

    public static void Log(Status status, string message, string imagePath)
    {
      if (ExistInstance())
      {
        return;
      }

      // Adicione a captura de tela do caminho da imagem ao relatório
      test.Value?.Log(status, message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(imagePath).Build());
    }

    public static bool ExistInstance()
    {
      if (test.Value == null)
      {
        return true;
      }
      return false;
    }

    public static void Close()
    {
      if (ExistInstance())
      {
        return;
      }
      extent.Flush();
    }
  }
}
