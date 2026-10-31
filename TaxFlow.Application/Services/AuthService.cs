namespace TaxFlow.Application.Services;
using TaxFlow.Application.DTOs.Auth;
using TaxFlow.Application.Interfaces;
using TaxFlow.Domain.Entities;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        if (await _userRepository.ExistsByEmailAsync(request.Email))
            throw new InvalidOperationException("Email is already registered.");

        var user = new User
        {
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = string.IsNullOrEmpty(request.Role) ? "User" : request.Role
        };

        await _userRepository.CreateAsync(user);
        var token = _tokenService.GenerateToken(user);

        return new AuthResponse(token, user.Email, $"{user.FirstName} {user.LastName}", user.Role, DateTime.UtcNow.AddHours(24));
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email) 
            ?? throw new UnauthorizedAccessException("Invalid email or password.");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid email or password.");

        var token = _tokenService.GenerateToken(user);

        return new AuthResponse(token, user.Email, $"{user.FirstName} {user.LastName}", user.Role, DateTime.UtcNow.AddHours(24));
    }
}