using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _sigInManager;

        public LogoutService(SignInManager<IdentityUser<int>> sigInManager)
        {
            _sigInManager = sigInManager;
        }

        public Result Logout()
        {
            var resultadoIdentity = _sigInManager.SignOutAsync();
            return resultadoIdentity.IsCompletedSuccessfully ? Result.Ok().WithSuccess("Deslogado com sucesso") : Result.Fail("Erro ao deslogar");
        }
    }
}