using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RefreshTokenWebApi.Data;
using RefreshTokenWebApi.Dto;
using RefreshTokenWebApi.Models;
using RefreshTokenWebApi.Services;

namespace RefreshTokenWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext dataContext, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var user = _dataContext.Users.SingleOrDefault(x => x.UserName == userDto.UserName);
            if (user!=null)
            {
                return StatusCode(409);
            }
            _dataContext.Users.Add(new User
            {
                UserName = userDto.UserName,
                Password= _passwordHasher.GenerateIdentityV3Hash(userDto.Password),
                Email=userDto.Email
            });
            await _dataContext.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var user = _dataContext.Users.SingleOrDefault(x => x.UserName == userDto.UserName);
            if (user == null)
            {
                return BadRequest();
            }
            if (!_passwordHasher.VerifyIdentityV3Hash(userDto.Password,user.Password))
            {
                return BadRequest();
            }

            var userClaims = new[]
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };
            var jwtToken = _tokenService.GenerateAccessToken(userClaims);
            var refreshToken = _tokenService.GenerateRefreshToken() +user.Id;

            return new ObjectResult(new
            {
                token = jwtToken,
                refreshToken = refreshToken
            });
        }
    }
}