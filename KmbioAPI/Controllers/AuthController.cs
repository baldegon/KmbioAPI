using KmbioAPI.DTOs;
using KmbioAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KmbioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }


        [HttpPost("registro")]
        [ProducesResponseType(typeof(AuthResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthResponseDTO>> Registrar([FromBody] RegistrarUsuarioDTO dto)
        {
            try
            {
                var response = await _authService.RegistrarAsync(dto);
                return CreatedAtAction(nameof(ObtenerPerfil), new { id = response.Usuario.Id }, response);
            }
        }
    }
}
