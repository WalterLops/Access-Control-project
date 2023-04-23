using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CastroUsuario([FromBody] CreateUsuarioDto creatUsuarioDto)
        {
            Result result = _cadastroService.CadastraUsuario(creatUsuarioDto);
            var retorno = new
            {
                creatUsuarioDto,
                codigoAtivacao = result.Reasons[0].Message
            };
            return result.IsSuccess ? Ok(retorno) : StatusCode(500);
        }
    }
}
    