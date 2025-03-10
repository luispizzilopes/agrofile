namespace AgroFile.Domain.Exceptions; 

internal class AgroFileDomainException : Exception
{
    public AgroFileDomainException(string message) : base(message) { }
}
