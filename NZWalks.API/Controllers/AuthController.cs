using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO.Auths;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenRepository _tokenRepository;

    public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
    {
        _userManager = userManager;
        _tokenRepository = tokenRepository;
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
                var roles = await _userManager.GetRolesAsync(user);

                if (roles != null)
                {
                    string token = _tokenRepository.CreateJWTToken(user, roles.ToList());

                    LoginResponseDto response = new LoginResponseDto()
                    {
                        jwtToken = token,
                    };

                    return Ok(response);
                }
            }
        }

        return BadRequest("Email or password is incorrect!");
    }
}