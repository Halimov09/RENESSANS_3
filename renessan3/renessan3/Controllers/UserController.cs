using Microsoft.AspNetCore.Mvc;
using renessan3.Models.Foundation;
using renessan3.Service.Foundation.User;
using System.Threading.Tasks;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IuserService userService;

    public UserController(IuserService userService)
    {
        this.userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] Users user)
    {
        if (user == null || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Course))
        {
            return BadRequest(new { status = "fail", message = "User data is invalid." });
        }

        try
        {
            var createdUser = await userService.AddUserAsync(user);
            return Ok(new { status = "pass", message = "User successfully created!", user = createdUser });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { status = "fail", message = "Server error: " + ex.Message });
        }
    }
}
