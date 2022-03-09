using CursoEFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CursoEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new ApplicationContext();

            var existe = db.Database.GetPendingMigrations().Any();

            if (existe)
            {
               
            }
        }
    }
}
