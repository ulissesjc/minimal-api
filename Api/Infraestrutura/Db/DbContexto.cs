using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using minimal_api.Domínio.Entidades;

namespace minimal_api.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {

        }

        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador
                {
                    Id = 1,
                    Email = "adm@teste.com",
                    Senha = "123456",
                    Perfil = "Adm"
                }
            );
        }
    }
}