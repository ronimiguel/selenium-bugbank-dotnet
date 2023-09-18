using OpenQA.Selenium;


namespace BugBankSelenium.Pages;
public class Locators
{
    // HomePage Registrar
    public static readonly By REGISTRAR_BTN = By.XPath("//button[contains(text(), 'Registrar')]");
    public static readonly By REGISTRAR_EMAIL_INPUT = By.XPath("(//input[@name='email'])[2]");
    public static readonly By REGISTRAR_NOME_INPUT = By.XPath("//input[@name='name']");
    public static readonly By REGISTRAR_SENHA_INPUT = By.XPath("(//input[@name='password'])[2]");
    public static readonly By REGISTRAR_CONFIRMAR_SENHA_INPUT = By.XPath("//input[@name='passwordConfirmation']");
    public static readonly By REGISTRAR_CRIAR_CONTA_COM_SALDO_BTN = By.Id("toggleAddBalance");
    public static readonly By REGISTRAR_CADASTRAR_BTN = By.XPath("//button[contains(text(), 'Cadastrar')]");
    public static readonly By REGISTRAR_MSG_CADASTRO_TXT = By.XPath("//p[contains(text(), 'criada com sucesso')]");

    // Acoes comuns
    public static readonly By FECHAR_BTN = By.Id("btnCloseModal");
    public static readonly By SAIR_BTN = By.Id("btnExit");
    public static readonly By VOLTAR_BTN = By.Id("btnBack");
    public static readonly By MSG_MODAL_TXT = By.Id("modalText");

    // HomePage Acessar
    public static readonly By ACESSAR_EMAIL_INPUT = By.XPath("(//input[@name='email'])[1]");
    public static readonly By ACESSAR_SENHA_INPUT = By.XPath("(//input[@name='password'])[1]");
    public static readonly By ACESSAR_BTN = By.XPath("//button[contains(text(), 'Acessar')]");

    // HomePage Text
    public static readonly By HOME_DADOS_CONTA_TXT = By.Id("toggleAddBalance");
    public static readonly By HOME_SALDO_CONTA_TXT = By.Id("textBalance");
    public static readonly By HOME_MSG_BEM_VINDO_TXT = By.Id("textName");

    // TransferenciaPage
    public static readonly By TRANSFERENCIA_BTN = By.XPath("//p[contains(text(), 'TRANSF')]/../a");
    public static readonly By TRANSFERENCIA_NUM_CONTA_INPUT = By.XPath("//input[@name='accountNumber']");
    public static readonly By TRANSFERENCIA_NUM_DIGITO_INPUT = By.XPath("//input[@name='digit']");
    public static readonly By TRANSFERENCIA_VALOR_INPUT = By.XPath("//input[@name='transferValue']");
    public static readonly By TRANSFERENCIA_DESCRICAO_INPUT = By.XPath("//input[@name='description']");
    public static readonly By TRANSFERENCIA_TRANSFERIR_AGORA_BTN = By.XPath("//button[contains(text(), 'Transferir agora')]");
    public static readonly By TRANSFERENCIA_MSG_TRANSFERENCIA_TXT = By.Id("modalText");

    // ExtratoPage
    public static readonly By EXTRATO_BTN = By.Id("btn-EXTRATO");
    public static readonly By EXTRATO_SALDO_DISPONIVEL_TXT = By.Id("textBalanceAvailable");
}
