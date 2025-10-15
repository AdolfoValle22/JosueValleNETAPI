using AuthApi.Entidades;
using AuthApi.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApi.TestXunit
{
    public class UsuarioRepositoryTest
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{System.Guid.NewGuid()}").Options;

            var context = new AppDbContext(options);

            context.Roles.Add(
                new Rol { Id = 1, Nombre = "Admin" }
            );

            context.Usuarios.Add(
                new Usuario
                {
                    Id = 2,
                    Nombre = "Josue",
                    Email = "josue@test.com",
                    PasswordHash = "123",
                    RolId = 1
                }
            );  

            context.SaveChanges();
            return context;
        }

        [Fact]
        public async Task GetByEmailAsync_RetornarUsuarioExistente()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new UsuarioRepository(context);
            // Act
            var usuario = await repo.GetByEmailAsync("josue@test.com");
            // Assert
            Assert.NotNull(usuario);
            Assert.Equal("Josue", usuario.Nombre);
            Assert.Equal("Admin", usuario.Rol.Nombre);

        }

        [Fact]
        public async Task AddAsync_AgregarNuevoUsuario()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new UsuarioRepository(context);

            var nuevoUsuario = new Usuario
            {
                Nombre = "Daniela",
                Email = "daniela@test.com",
                PasswordHash = "123",
                RolId = 1
            };

            // Act
            await repo.AddAsync(nuevoUsuario);

            // Assert
            var usuarioGuardado = await context.Usuarios.FirstOrDefaultAsync(u => u.Email == "daniela@test.com");

            Assert.NotNull(usuarioGuardado);
            Assert.Equal("Daniela", usuarioGuardado.Nombre);
        }


    }
}
