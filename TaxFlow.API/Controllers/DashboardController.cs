namespace TaxFlow.API.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize] // 👈 Requires ANY valid JWT token
public class DashboardController : ControllerBase
{
    [HttpGet("user-data")]
    public IActionResult GetUserDashboard()
    {
        return Ok(new { message = "Welcome to your dashboard!", user = User.Identity?.Name });
    }

    [HttpGet("admin-data")]
    [Authorize(Roles = "Admin")] // 👈 Requires JWT token WITH "Admin" role claim
    public IActionResult GetAdminDashboard()
    {
        return Ok(new { message = "Welcome to the ADMIN dashboard!" });
    }
}