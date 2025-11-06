using KmbioAPI.DTOs;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace KmbioAPI.Interfaces
{
    public class IAuthService
    {
        Task<AuthResponseDTO> RegistrarAsync(RegistrarUsuarioDTO dto);
        Task<AuthResponseDTO> LoginAsync(LoginDTO dto);
        Task<UsuarioDTO> ObtenerPerfilAsync(int usuarioId);

    }
}
