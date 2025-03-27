namespace AgroFile.Application.Messages;

internal class MessagesAuthenticationAgroFileApplication
{
    public static string AuthenticationSuccess = "Email ou a senha estão inválidos!";

    public static string AuthenticationFailure = "Email ou a senha estão inválidos!";
    public static string EmailNotConfirmed = "Não foi possível realizar a autenticação pois o endereço de e-mail não foi confirmado!";

    public static string SendMailPasswordResetSuccess = "E-mail de redefinição de senha enviado com sucesso!"; 
    public static string SendMailPasswordResetFailure = "Não foi possível enviar o e-mail de redefinição de senha!";

    public static string ConfirmPasswordResetSuccess = "Senha redefinida com sucesso. Verifique sua caixa de e-mail!"; 
    public static string ConfirmPasswordResetFailure = "Não foi possível confirmar a redefinição de senha!"; 
}
