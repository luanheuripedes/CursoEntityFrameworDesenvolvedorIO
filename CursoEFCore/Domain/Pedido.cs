using CursoEFCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEFCore.Domain
{
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime IniciadoEm { get; set; }

        public DateTime FinalizadoEm { get; set; }

        public TipoFrete TipoFrete { get; set; }

        public StatusPedido Status { get; set; }

        public string Observacao { get; set; }

        //FK
        public int ClienteId { get; set; }

        //Propriedades de Navegação
        public Cliente Cliente { get; set; } //prop de navegação
        public ICollection<PedidoItem> Itens { get; set; }
    }
}
