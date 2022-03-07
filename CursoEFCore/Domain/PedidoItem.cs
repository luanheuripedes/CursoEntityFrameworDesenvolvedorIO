using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEFCore.Domain
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public int Quantidade{ get; set; }
        //FK
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }

        ////Propriedades de Navegação
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }
}
