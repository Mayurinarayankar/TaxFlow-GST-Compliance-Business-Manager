namespace TaxFlow.Application.Interfaces;
using TaxFlow.Application.DTOs.Auth;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse> LoginAsync(LoginRequest request);
}