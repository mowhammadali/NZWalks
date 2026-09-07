using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO.Auths;

namespace NZWalks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequest)
    {
        var identityUser = new IdentityUser()
        {
            UserName = registerRequest.Email,
            Email = registerRequest.Email,
        };

        var identityResult = await _userManager.CreateAsync(identityUser, registerRequest.Password);

        if (identityResult.Succeeded)
        {
            if (registerRequest.Roles != null && registerRequest.Roles.Any())
            {
                identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequest.Roles);

                if (identityResult.Succeeded)
                {
                    return Ok("You have successfully registered!");
                }
            }
        }

        return BadRequest("Something went wrong!");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email);

        if (user != null)
        {
            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (isPasswordCorrect)
            {
                return Ok("You have successfully logged in!");
            }
        }

        return BadRequest("Email or password is incorrect!");
    }
}