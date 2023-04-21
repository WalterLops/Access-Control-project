using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
        [Required]
        [Compare("Password")]
        public string Email { get; set; }

    }
}
