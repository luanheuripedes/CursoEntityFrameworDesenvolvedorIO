using CursoEFCore.Context;
using CursoEFCore.Domain;
using CursoEFCore.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

            //InserirDados();
            //InserirDadosEmMassa();
            ConsultarDados();

        }

        private static void ConsultarDados()
        {
            var db = new ApplicationContext();

            //var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();
            var consultaPorMetodo = db.Clientes
                    .Where(p => p.Id > 0)
                    .OrderBy(p => p.Id)
                    .ToList();

            foreach (var cliente in consultaPorMetodo)
            {
                Console.WriteLine("Consultado o cliente " + cliente.Id);
                //db.Clientes.Find(cliente.Id); //Responsavel por consultar se esta em memoria ou nao é o unico
                db.Clientes.FirstOrDefault(p => p.Id == cliente.Id);
            }

        }
        private static void InserirDadosEmMassa()
        {
            var p1 = new Produto("123456789123","Produto teste Inserir em massa2"
                                    , 18.45m, TipoProduto.MercadoriaParaRevenda, false);

            //var c1 = new Cliente("Rafael Almeida", "3331-8838", "36900000", "MG", "Manhuaçu", "rafael@gmail.com");
            

            List<Cliente> listaClientes = new List<Cliente>();

            var c1 = new Cliente("Lucas", "7777-8838", "78900000", "MG", "Manhuaçu", "Lucas@gmail.com");
            var c2 = new Cliente("Almeida", "5555-8838", "15400000", "MG", "Manhuaçu", "Almeida@gmail.com");

            listaClientes.Add(c1);
            listaClientes.Add(c2);

            using var db = new ApplicationContext();
            //db.AddRange(c1, p1);

            db.Clientes.AddRange(listaClientes);
            //db.Set<Cliente>().AddRange(listaClientes);

            var registors = db.SaveChanges();
            Console.WriteLine("Total de registros"+registors);
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
            Console.WriteLine("Total de registros" + registros);

        }
    }

}
