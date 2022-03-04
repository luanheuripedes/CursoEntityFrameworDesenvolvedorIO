using Microsoft.EntityFrameworkCore;
using System;

namespace CursoEFCore.Context
{
    public class ApplicationContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=EfCoreIntroducao;Uid=root;Pwd=123456789;",
                                    new MySqlServerVersion(new Version(10, 4, 17)));
        }
    }
}
