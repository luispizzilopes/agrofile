namespace AgroFile.Application.Consts;

public class Templates
{
    public static string BaseNameTemplate = "Template{nome}.html";
    public static string TemplatePasswordUser => BaseNameTemplate.Replace("{nome}", "EmailSenhaUsuario");
    public static string TemplateTokenPasswordUser => BaseNameTemplate.Replace("{nome}", "RedefinicaoSenhaUsuario"); 
}
