using KmbioAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KmbioAPI.Data
{
    public class KmbioSeeder
    {
        public static async Task SeedAsync(KmbioDbContext context, UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
        {
            if(!userManager.Users.Any())
            {
                var adminUser = new Usuario
                {
                    UserName = "Admin",
                    Email = "admin@kmbio.com",
                    EmailConfirmed = true,
                    CreatedAt = DateTime.UtcNow,
                    CurrencyDefault = "USD"
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }

                var clienteUser = new Usuario
                {
                    UserName = "test",
                    Email = "test@kmbio.com",
                    EmailConfirmed = true,
                    CreatedAt = DateTime.UtcNow,
                    CurrencyDefault = "USD"
                };

                var resultClient = await userManager.CreateAsync(clienteUser, "Test123!");
                if (resultClient.Succeeded)
                {
                    await userManager.AddToRoleAsync(clienteUser, "Client");

                    var clientId = clienteUser.Id;

                    await SeedCategorias(context, clientId);

                    await SeedMetodosPago(context, clientId);

                    await SeedPresupuesto(context, clientId);
                }
            }
        }

        private static async Task SeedCategorias(KmbioDbContext context, string userId)
        {
            if(!context.Categorias.Any())
            {
                var categorias = new List<Categoria>
                {
                    new Categoria { Nombre = "Alimentos", UserId = userId },
                    new Categoria { Nombre = "Transporte", UserId = userId },
                    new Categoria { Nombre = "Entrenenimiento", UserId = userId },
                    new Categoria { Nombre = "Servicios", UserId = userId }
                };

               context.Categorias.AddRange(categorias);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedMetodosPago(KmbioDbContext context, string userId)
        {
            if (!context.MetodosDePagos.Any())
            {
                var metodos = new List<MetodosDePago>
                {
                    new MetodosDePago { NombreMetodo = "Efectivo", UserId = userId, Active = true},
                    new MetodosDePago { NombreMetodo = "Debito", UserId = userId, Active = true},
                };

                context.MetodosDePagos.AddRange(metodos);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedPresupuesto(KmbioDbContext context, string userId)
        {
            if(!context.Presupuestos.Any())
            {
                var fechaActual = DateTime.UtcNow;
                var primerDiaMes = new DateTime(fechaActual.Year, fechaActual.Month, 1);
                var ultimoDiaMes  = primerDiaMes.AddMonths(1).AddDays(-1);

                var presupuestos = new List<Presupuesto>
                {
                    new Presupuesto { MontoLimite = 100000, UserId = userId, FechaInicio = primerDiaMes, FechaFin = ultimoDiaMes, CreatedAt = DateTime.UtcNow, Frecuencia = "MENSUAL"}
                };

                context.Presupuestos.AddRange(presupuestos);
                await context.SaveChangesAsync();
            }
        }
    }
}
