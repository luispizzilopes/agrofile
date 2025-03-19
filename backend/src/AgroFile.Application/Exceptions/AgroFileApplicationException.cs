namespace AgroFile.Application.Exceptions; 

internal class AgroFileApplicationException : Exception
{
    public AgroFileApplicationException(string message) : base(message) { }
}
