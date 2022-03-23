using CursoEFCore.Data.Configurations;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace CursoEFCore.Context
{
    public class ApplicationContext:DbContext
    {
        private static readonly ILoggerFactory _Logger = LoggerFactory.Create(p => p.AddConsole());
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder
                .UseLoggerFactory(_Logger) //Informa qual log quero utilizar
                .EnableSensitiveDataLogging() // Para ver o valor de cada parametro no console
                .UseMySql("Server=localhost;Database=EfCoreIntroducao;Uid=root;Pwd=123456789;",
                                    new MySqlServerVersion(new Version(10, 4, 17)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Adiciona as configurações feitas separadas na hora de gerar o banco
            //modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            //modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            //modelBuilder.ApplyConfiguration(new PedidoItemConfiguration());
            //modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

            //Adiciona as configurações feitas separadas na hora de gerar o banco
            //Passo o typeof da propria classe e ele procura todas as classes concretas que implementam
            //object IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);


        }
    }
}
