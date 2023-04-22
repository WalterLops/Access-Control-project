using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Requests;

namespace UsuariosAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _sigInManager;

        public LoginService(SignInManager<IdentityUser<int>> sigInManager)
        {
            _sigInManager = sigInManager;
        }

        public Result LogaUsuario(LoginRequest loginRequest)
        {
            var resultado = _sigInManager
                .PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
            return resultado.Result.Succeeded ? Result.Ok() : Result.Fail("Erro ao logar");
        }
    }
}