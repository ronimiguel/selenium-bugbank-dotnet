using Bogus;

namespace BugBankSelenium.Utils;
public class GerarDadosClientes
{
  private readonly Faker<Cliente> _faker;

  public GerarDadosClientes()
  {
    _faker = new Faker<Cliente>("pt_BR")
        .RuleFor(c => c.Email, f => f.Person.Email)
        .RuleFor(c => c.Nome, f => f.Person.FullName)
        .RuleFor(c => c.Senha, f => f.Internet.Password())
        .RuleFor(c => c.ConfirmarSenha, (f, c) => c.Senha); // ConfirmarSenha igual à Senha
  }

  public Cliente NovoCliente()
  {
    return _faker.Generate();
  }

  public decimal ValorTransferencia()
  {
    var valorAleatorio = new Faker().Random.Double(0.01, 1000.00);
    return decimal.Round((decimal)valorAleatorio, 2);
  }

  public string DescricaoTransferencia()
  {
    var faker = new Faker("pt_BR");
    return faker.Commerce.ProductName();
  }

}
