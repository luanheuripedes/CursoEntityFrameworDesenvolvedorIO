using CursoEFCore.Data.Configurations;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CursoEFCore.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=EfCoreIntroducao;Uid=root;Pwd=123456789;",
                                    new MySqlServerVersion(new Version(10, 4, 17)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Adiciona as configurações feitas separadas na hora de gerar o banco
            //modelBuilder.ApplyConfiguration(new PedidoConfiguration());

            //Adiciona as configurações feitas separadas na hora de gerar o banco
            //Passo o typeof da propria classe e ele procura todas as classes concretas que implementam
            //object IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);


        }
    }
}
