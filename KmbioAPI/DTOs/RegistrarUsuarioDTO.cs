using System.ComponentModel.DataAnnotations;

namespace KmbioAPI.DTOs
{
    public class RegistrarUsuarioDTO
    {
        [Required(ErrorMessage = "El EMAIL es requerido")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="La contraseña es requerida")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre { get; set; }
    }
}
