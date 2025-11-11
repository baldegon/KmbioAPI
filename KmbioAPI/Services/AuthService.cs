using KmbioAPI.DTOs;
using KmbioAPI.Interfaces;
using KmbioAPI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

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

        public async Task<AuthResponseDTO> RegistrarAsync(RegistrarUsarioDTO dto)
        {
            if (await _usuarioRepository.ExisteEmailAsync(dto.Email))
            {
                throw new Exception("El email ya está en uso.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var usuario = new Usuario
            {
                Email = dto.Email,
                Nombre = dto.Nombre,
                PasswordHash = passwordHash,
                FechaRegistro = DateTime.UtcNow
            };

            await _usuarioRepository.CrearAsync(usuario);

            var token = GenerarTokenJWT(usuario);

            return new AuthResponseDTO
            {
                Token = token,
                Usuario = _mapper.Map<UsuarioDTO>(usuario)
            };
        }

        public async Task<UsuarioDTO> ObtenerPerfilesAsync(int usuarioId)
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(usuarioId);

            if (usuario == null){
                throw new Exception("Usuario no encontrado.");

            }
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        private string GenerarTokenJWT(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Name, usuario.Nombre)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigninCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
