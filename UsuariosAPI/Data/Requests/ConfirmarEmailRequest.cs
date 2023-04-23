using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class ConfirmarEmailRequest
    {
        [Required]
        public string UsuarioId { get; set; }
        
        [Required]
        public string CodigoAtivacao { get; set; }
    }
}