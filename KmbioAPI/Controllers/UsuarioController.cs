using KmbioAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KmbioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly KmbioDbContext _context;

        public UsuarioController(KmbioDbContext context)
        {
            _context = context;
        }

    }
}
