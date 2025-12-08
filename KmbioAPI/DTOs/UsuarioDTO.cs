namespace KmbioAPI.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }    
        public DateTime FechaCreado { get; set; }
    }
}
