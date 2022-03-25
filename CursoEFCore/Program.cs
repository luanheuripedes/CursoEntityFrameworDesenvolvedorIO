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
            //ConsultarDados();
            //CadastrarPedido();
            //ConsultarPedidoCarregamentoAdiantado();
            //AtualizarDados();
            RemoverRegistro();
        }

        private static void RemoverRegistro()
        {
            using var db = new ApplicationContext();

            /*
            var cliente = db.Clientes.Find(3);
            //db.Clientes.Remove(cliente);
            //db.Remove(cliente);
            //Informo ao EFCORE qual objeot eu vou estar manipulando
            //e uso a propriedade State para informar o que eu quero fazer com o objeto
            db.Entry(cliente).State = EntityState.Deleted;
            db.SaveChanges();
            */

            //Forma desconectada
            var cliente = new Cliente { Id = 4 };
            db.Entry(cliente).State = EntityState.Deleted;
            db.SaveChanges();

        }
        private static void AtualizarDados()
        {
            using var db = new ApplicationContext();

            /*Atualiza toda a entidade no banco
            //var cliente = db.Clientes.FirstOrDefault(c => c.Id == 3);
            var cliente = db.Clientes.Find(3);

            cliente.Nome = "Cliente alterado Passo 1";

            db.Clientes.Update(cliente)
            db.SaveChanges();
            */


            /*Não atualiza toda entidade no banco
            //var cliente = db.Clientes.FirstOrDefault(c => c.Id == 3);
            var cliente = db.Clientes.Find(3);

            cliente.Nome = "Cliente alterado Passo 2";

            db.SaveChanges();
            */


            //Atraves do Rastreamento Informa que a entidade esta recebendo uma alteração
            /*
            var cliente = db.Clientes.Find(3);

            cliente.Nome = "Cliente alterado Passo 3";
            
            db.Entry(cliente).State = EntityState.Modified;

            db.SaveChanges();
            */


            /*
            //Desconectado - Os dados nao estao instanciados ainda
            var cliente = db.Clientes.Find(3);

            var clienteDesconectado = new
            {
                Nome = "Cliente desconectado passo 4",
                Telefone = "777555111"
            };

            db.Entry(cliente).CurrentValues.SetValues(clienteDesconectado);
            
            db.SaveChanges();
            */



            //Temos a instacia do cliente

            var cliente = new Cliente
            {
                Id = 3
            };

            var clienteDesconectado = new
            {
                Nome = "Cliente desconectado passo 5",
                Telefone = "777555111"
            };

            db.Attach(cliente); //Para que o objeto comece a ser rastreado
            db.Entry(cliente).CurrentValues.SetValues(clienteDesconectado);

            db.SaveChanges();

        }
        private static void ConsultarPedidoCarregamentoAdiantado()
        {
            using var db = new ApplicationContext();
            //var pedidos = db.Pedidos.Include(p => p.Itens).ToList(); // carrega os itens
            var pedidos = db.Pedidos
                    .Include(p => p.Itens)
                    .ThenInclude(p=>p.Produto)
                    .ToList(); //carrega os itens e produtos


            Console.WriteLine(pedidos.Count);
        }
        private static void CadastrarPedido()
        {
            using var db = new ApplicationContext();

            //Consulta de um cliente e um produto
            var cliente = db.Clientes.FirstOrDefault(x => x.Id == 3);
            var produto = db.Produtos.FirstOrDefault(x => x.Id == 2);

            var pedido = new Pedido
            {
                ClienteId = cliente.Id,
                IniciadoEm = DateTime.Now,
                FinalizadoEm = DateTime.Now,
                Observacao = "Pedido Teste",
                Status = StatusPedido.Analise,
                TipoFrete = TipoFrete.SemFrete,
                Itens = new List<PedidoItem>()
                {
                    new PedidoItem
                    {
                        ProdutoId = produto.Id,
                        Desconto = 0,
                        Quantidade = 1,
                        Valor = 10,
                    }
                }
            };
            db.Pedidos.Add(pedido);
            db.SaveChanges();
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
                Console.WriteLine(cliente.Cidade + cliente.Email);
                //Console.WriteLine("Consultado o cliente " + cliente.Id);
                //db.Clientes.Find(cliente.Id); //Responsavel por consultar se esta em memoria ou nao é o unico
                //db.Clientes.FirstOrDefault(p => p.Id == cliente.Id);
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
