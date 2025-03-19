using AgroFile.Application.Consts;
using AgroFile.Application.Interfaces;
using System.Text;

namespace AgroFile.Application.Services;

public class PasswordService : IPasswordService
{
    private readonly Random Random = new();

    public string GenerateRandomPassword()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append(PatternsPassword.UppercaseLetters[Random.Next(PatternsPassword.UppercaseLetters.Length)]);
        stringBuilder.Append(PatternsPassword.LowercaseLetters[Random.Next(PatternsPassword.LowercaseLetters.Length)]);
        stringBuilder.Append(PatternsPassword.SpecialCharacters[Random.Next(PatternsPassword.SpecialCharacters.Length)]);
        stringBuilder.Append(PatternsPassword.Digits[Random.Next(PatternsPassword.Digits.Length)]);

        for (int i = 4; i < 8; i++)
        {
            stringBuilder.Append(PatternsPassword.AllCharacters[Random.Next(PatternsPassword.AllCharacters.Length)]);
        }

        return new string(stringBuilder.ToString().ToCharArray().OrderBy(_ => Random.Next()).ToArray());
    }
}
