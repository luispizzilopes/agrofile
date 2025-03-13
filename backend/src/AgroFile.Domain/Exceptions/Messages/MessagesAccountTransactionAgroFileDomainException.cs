namespace AgroFile.Domain.Exceptions.Messages;

internal class MessagesAccountTransactionAgroFileDomainException
{
    public static string TotalPriceIsRequired = "O preço total é obrigatório e deve ser maior que zero";
    public static string InvalidTypeTransaction = "O tipo de transação informado é inválido";
    public static string InvalidStatusAccountTransaction = "O status da transação informado é inválido";
}
