namespace TaxFlow.Application.Interfaces;
using TaxFlow.Domain.Entities;

public interface ITokenService
{
    string GenerateToken(User user);
}