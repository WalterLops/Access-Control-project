using System.Linq;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _sigInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> sigInManager, TokenService tokenService)
        {
            _sigInManager = sigInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest loginRequest)
        {
            var resultado = _sigInManager
                .PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
            if (resultado.Result.Succeeded)
            {
                var identityUser = _sigInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(user => user.NormalizedUserName == loginRequest.Username.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Usuário ou senha inválidos");
        }
    }
}