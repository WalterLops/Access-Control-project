using FilmesApi.Data.Dtos.Sessao;
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Services;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }
        
        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            ReadSessaoDto sessaoDto = _sessaoService.AdicionaSessao(dto);
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessaoDto.Id }, sessaoDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            ReadSessaoDto sessaoDto = _sessaoService.RecuperaSessoesPorId(id);
            if (sessaoDto != null)
            {
                return Ok(sessaoDto);
            }
            return NotFound();
        }
    }
}
