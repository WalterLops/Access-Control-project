

using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private LoginService _loginService;
        private TokenService _tokenService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario([FromBody] LoginRequest loginRequest)
        {   
            Result result = _loginService.LogaUsuario(loginRequest);
            return result.IsSuccess ? Ok(result.Reasons[0]) : Unauthorized(result.Reasons[0]);
        }

    }
}