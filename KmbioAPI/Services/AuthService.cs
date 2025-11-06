using KmbioAPI.DTOs;
using KmbioAPI.Interfaces;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace KmbioAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(
            IUsuarioRepository usuarioRepository,
            IConfiguration configuration,
            IMapper mapper)
        {
            _usuarioRepository = usuarioRepository,
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<AuthResponseDTO> RegistrarAsync(RegistrarUusarioDTO dto)
        {

        }
    }
}
