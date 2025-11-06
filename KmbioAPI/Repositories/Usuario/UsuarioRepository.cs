using KmbioAPI.Interfaces;
using KmbioAPI.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace KmbioAPI.Repositories.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly KmbioDbContext _context;

        public UsuarioRepository(KmbioDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> ObtenerPorEmailAsync(string email)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<Usuario> CrearAync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> ExisteEmailAsync(string email)
        {
            return await _context.Usuarios
                .AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }
    }
}
