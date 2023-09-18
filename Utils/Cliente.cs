namespace BugBankSelenium.Utils;
public class Cliente
{
  public string? Email { get; set; }
  public string? Nome { get; set; }
  public string? Senha { get; set; }
  public string? ConfirmarSenha { get; set; }
  public bool? PossuiConta { get; set; }
  public string? NumeroConta { get; set; }
  public string? NumeroDigito { get; set; }
  public decimal? SaldoInicial { get; set; }
  public decimal? SaldoAtual { get; set; }

  public Cliente(string email, string nome, string senha, string confirmarSenha)
  {
    Email = email;
    Nome = nome;
    Senha = senha;
    ConfirmarSenha = confirmarSenha;
    PossuiConta = false; // Inicialmente, o cliente não possui conta
  }

  public Cliente()
  {

  }
}