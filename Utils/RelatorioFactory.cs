using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using NUnit.Framework;
using System;
using System.IO;

namespace BugBankSelenium.Utils
{
  public class RelatorioFactory
  {
    // public static readonly string Caminho_Salvar_Relatorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Relatorio_Execucao", "Relatorio_" + DateTime.Now.ToString("ddMMyyyy_HHmmss"));
    public static readonly string Caminho_Salvar_Relatorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Relatorios");

    private static ExtentSparkReporter? sparkReporter;
    private static ExtentReports? extentReports;

    private static string? nomeDoRelatorio;

    public static ExtentReports? GetInstance()
    {
      if (extentReports == null)
      {
        NovoRelatorio();
      }
      return extentReports;
    }

    public static void NomeDoRelatorio(string nome)
    {
      nomeDoRelatorio = nome;
    }

    public static void NovoRelatorio()
    {
      CriarPastaRelatorio(Caminho_Salvar_Relatorio);
      string nomeArquivo = Path.Combine(Caminho_Salvar_Relatorio, "Relatorio_" + DateTime.Now.ToString("dd-MM-yy_HHmmss") + ".html");
      sparkReporter = new ExtentSparkReporter(nomeArquivo);
      sparkReporter.Config.DocumentTitle = "Relatório de Execução dos Testes";
      if (nomeDoRelatorio == null)
      {
        sparkReporter.Config.ReportName = "Relatório de Execução dos Testes";
      }
      else
      {
        sparkReporter.Config.ReportName = nomeDoRelatorio;
      }
      sparkReporter.Config.Theme = Theme.Dark;
      extentReports = new ExtentReports();
      extentReports.AttachReporter(sparkReporter);
      TestContext.Progress.WriteLine("Relatorio criado: " + nomeArquivo);
    }

    private static void CriarPastaRelatorio(string path)
    {
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }
    }
  }
}
