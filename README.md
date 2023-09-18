# Automação de Transferência de Valores entre Contas

## Sobre o Teste

O objetivo deste teste automatizado é criar duas contas com saldo, realizar uma transferência entre essas contas e validar a saída e entrada de valores nas contas envolvidas no site [https://bugbank.netlify.app](https://bugbank.netlify.app).

### Ferramentas Utilizadas

Os testes foram desenvolvidos utilizando as seguintes ferramentas:

- Selenium WebDriver: Para interagir com a página web.
- NUnit 3: Para criar as assertivas e gerenciar os testes.
- Extent Reports: Para gerar relatórios de execução dos testes.
- Bogus: Para gerar dados aleatórios de clientes.

### Dependências

Certifique-se de ter as seguintes dependências instaladas em seu projeto .NET:

- Selenium WebDriver: Para interagir com a página web.
- NUnit 3: Para criação de assertivas e gerenciamento de testes.
- Extent Reports: Para geração de relatórios de execução dos testes.
- Bogus: Para geração de dados aleatórios de clientes.

### Executando os Testes

Antes de começar, certifique-se de ter o seguinte configurado em sua máquina:

- Visual Studio (ou qualquer outra IDE compatível com .NET) instalado.
- WebDriver (por exemplo, ChromeDriver) instalado e configurado nas variáveis de ambiente.

Para executar os testes, siga os passos abaixo:

1. Abra o Visual Studio.
2. Clone este repositório para a sua máquina.
3. Abra o projeto no Visual Studio.

#### Opção 1: Usando o .NET CLI

No terminal, navegue até a pasta raiz do projeto:

```bash
dotnet test
```

#### Opção 2: Usando o Visual Studio

1. No Visual Studio, abra o Test Explorer.
2. Clique com o botão direito do mouse na classe `RealizarTransferenciaEntreContasTest` no Solution Explorer.
3. Selecione "Executar".

#### Relatório de Execução dos testes
Ao final da execução, um arquivo chamado `Relatorio_diaMesAno_hora.html` será gerado dentro da pasta Relatorios na raiz do projeto. Esse arquivo conterá informações detalhadas sobre a execução dos testes, incluindo evidências em forma de screenshots.
