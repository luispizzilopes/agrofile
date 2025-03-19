namespace AgroFile.Application.Consts;

internal static class PatternsPassword
{
    public const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
    public const string SpecialCharacters = "!@#$%^&*()-_=+[]{}|;:,.<>?/";
    public const string Digits = "0123456789";
    public const string AllCharacters = UppercaseLetters + LowercaseLetters + SpecialCharacters + Digits;
}
