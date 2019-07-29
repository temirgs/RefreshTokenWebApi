using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RefreshTokenWebApi.Data;
using RefreshTokenWebApi.Services;

namespace RefreshTokenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly DataContext _dataContext;
        public TokenController(ITokenService tokenService, DataContext dataContext)
        {
            _tokenService = tokenService;
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> Refresh(string token,string refreshToken)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            var user = _dataContext.Users.SingleOrDefault(x => x.UserName == username);

            if (user == null) //refreshtokenide tap!
            {
                return BadRequest();
            }

            var newJwtToken = _tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken() + user.Id;

            return new ObjectResult(new
            {
                token=newJwtToken,
                refreshToken=newRefreshToken
            });
        }
    }
}