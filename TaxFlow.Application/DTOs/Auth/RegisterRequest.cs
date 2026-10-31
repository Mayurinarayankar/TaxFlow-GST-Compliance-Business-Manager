namespace TaxFlow.Application.DTOs.Auth;

public record RegisterRequest(
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string? Role = "User" // Optional, defaults to "User"
);