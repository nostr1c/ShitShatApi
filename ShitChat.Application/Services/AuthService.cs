﻿using ShitChat.Infrastructure.Data;
using ShitChat.Domain.Entities;
using ShitChat.Shared.Extensions;
using ShitChat.Application.DTOs;
using ShitChat.Application.Requests;
using ShitChat.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ShitChat.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _config;
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService
    (
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IConfiguration config,
        AppDbContext dbContext,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<User?> RegisterUserAsync(CreateUserRequest request)
    {
        var user = new User
        {
            UserName = request.Username,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return null;
        }
        // Check errors

        return user;
    }

    public async Task<(bool, string, LoginUserDto)> LoginUserAsync(LoginUserRequest request)
    {
        bool success;
        string message = "";

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            success = false;
            message = "Invalid Email or Password";
            return (success, message, null);
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!result.Succeeded)
        {
            success = false;
            message = "Invalid Email or Password";
            return (success, message, null);
        }

        var token = await CreateToken(user.Id, true);

        var userDto = new LoginUserDto
        {
            Id = user.Id,
            Token = token,
        };

        success = true;
        message = "Successfully logged in.";

        return (success, message, userDto);
    }
    public async Task<TokenDto> CreateToken(string userId, bool populateExpiry)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var jwtKey = _config["Jwt:Key"];
        var jwtIssuer = _config["Jwt:Issuer"];

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
        var signingKey = new SymmetricSecurityKey(keyBytes);

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtIssuer,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(5),
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
        );

        var refreshToken = CreateRefreshToken();

        if (user != null)
        {
            user.RefreshToken = refreshToken;

            if (populateExpiry)
            {
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            }
            await _userManager.UpdateAsync(user);
        }


        var tokenDto = new TokenDto(new JwtSecurityTokenHandler().WriteToken(token), refreshToken);

        return tokenDto;
    }

    private string CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }

    public async Task<(bool, TokenDto?)> RefreshToken(TokenDto tokenDto)
    {
        if (string.IsNullOrEmpty(tokenDto.RefreshTokenn))
        {
            return (false, null);
        }

        var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.RefreshToken == tokenDto.RefreshTokenn);

        if (user is null || user.RefreshToken != tokenDto.RefreshTokenn || user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            return (false, null);
        }

        var newTokenDto = await CreateToken(user.Id, true);

        user.RefreshToken = newTokenDto.RefreshTokenn;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

        await _dbContext.SaveChangesAsync();


        return (true, newTokenDto);
    }

    public void SetTokensInsideCookie(TokenDto tokenDto, HttpContext context)
    {
        context.Response.Cookies.Append("accessToken", tokenDto.AccessToken,
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddMinutes(5),
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });

        context.Response.Cookies.Append("refreshToken", tokenDto.RefreshTokenn,
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7),
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });
    }

    public async Task<UserDto?> GetCurrentUserAsync()
    {
        var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetUserGuid());
        if (user is null)
            return null;

        var userDto = new UserDto
        {
            Id = user.Id,
            Username = user.UserName,
            Email = user.Email,
            Avatar = user.AvatarUri,
            CreatedAt = user.CreatedAt
        };

        return userDto;
    }
}