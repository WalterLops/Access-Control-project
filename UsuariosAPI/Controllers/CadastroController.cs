using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Data.Requests;
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
        
        [HttpGet]
        [Route("/ConfirmarEmail")]
        public IActionResult ConfirmarEmail([FromQuery] ConfirmarEmailRequest confirmarEmailRequest)
        {
            Result result = _cadastroService.ConfirmarEmail(confirmarEmailRequest);
            return result.IsSuccess ? Ok(result.Reasons[0].Message) : StatusCode(500);
        }
    }
}
    