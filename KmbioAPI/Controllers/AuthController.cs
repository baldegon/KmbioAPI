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

        //Registro de usuario

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
            catch (BadRequestException ex)
            {
                return BadRequest(new { mensaje = Exception.Message })
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar usuario");
                return StatusCode(500, new { mensaje = "Error interno del servidor" });
                
            }
        }

        //Inicio de Sesion

        [HttpPost("login)")]
        [ProducesResponseType(typeof(AuthResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthResponseDTO>> Login([FromBody] LoginDTO dto)
        {
            try
            {
                var response = await _authService.LoginAsync(dto);
                return Ok(Response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al iniciar sesión");
                return StatusCode(500, new { mensaje = "Error interno del servidor" });
            }
        }
    }

    [HttpGet("perfil")]
    [Authorize]
    [ProducesResponseType(typeof(AuthResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UsuarioDTO>> ObtenerPerfil()
    {

    }

}
