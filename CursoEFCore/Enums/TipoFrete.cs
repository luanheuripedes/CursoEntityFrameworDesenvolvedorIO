using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEFCore.Enums
{
    public enum TipoFrete
    {
        CIF = 0, //remetente paga o frete
        FOB = 1, //destinario paga
        SemFrete = 2
    }
}
