using AgroFile.Application.Exceptions;
using AgroFile.Application.Interfaces;
using AgroFile.Application.Messages;

namespace AgroFile.Application.Services;

public class TemplateService : ITemplateService
{
    public string GetTemplate(string name)
    {
        string pathTemplates = GetPathTemplates(); 
        string pathTemplateFile = Path.Combine(pathTemplates, name);

        if (File.Exists(pathTemplateFile))
            return File.ReadAllText(pathTemplateFile);

        throw new AgroFileApplicationException(MessagesTemplateAgroFileApplication.TemplateNotFound); 
    }

    private string GetPathTemplates()
    {
        return Path.Combine(
        [
            Directory.GetCurrentDirectory(),
                "wwwroot",
                "Templates"
        ]);
    }
}
