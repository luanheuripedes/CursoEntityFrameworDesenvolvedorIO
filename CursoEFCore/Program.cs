using CursoEFCore.Context;
using CursoEFCore.Domain;
using CursoEFCore.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CursoEFCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            using var db = new ApplicationContext();

            var existe = db.Database.GetPendingMigrations().Any();

            if (existe)
            {
               
            }
            */

            InserirDados();

        }

        private static void InserirDados()
        {
            var p1 = new Produto("Produto Teste",
                                        "123456789123", 10.75m, TipoProduto.MercadoriaParaRevenda,true);

            var db = new ApplicationContext();

            // *** Adicionar *** Apenas rastreado
            //db.Produtos.Add(p1);
            //db.Set<Produto>().Add(p1);
            //db.Entry(p1).State = EntityState.Added; ///Forçar o rastreamento da entidade
            db.Add(p1);//Propria instacia do contexto

            //retorna a quantidade de registros que foram afetados na base de dados *joga no banco
            var registros = db.SaveChanges();
            Console.WriteLine(registros);

        }
    }

}
