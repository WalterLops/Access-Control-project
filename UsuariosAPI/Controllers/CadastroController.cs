using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        public IActionResult CastroUsuario(CreateUsuarioDto creatUsuarioDto) 
        { 
            //TODO comandos
            return Ok(creatUsuarioDto);
        }
    }
}
