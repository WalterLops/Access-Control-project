using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutContoller : ControllerBase
    {
        LogoutService _logoutService;
        
        public LogoutContoller(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }
        
        [HttpPost]
        public IActionResult Logout()
        {
            Result result = _logoutService.Logout();
            return result.IsSuccess ? Ok(result.Reasons[0]) : Unauthorized(result.Reasons[0]);
        }
    }
}