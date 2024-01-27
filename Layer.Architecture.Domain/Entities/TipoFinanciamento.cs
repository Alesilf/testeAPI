using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Domain.Entities
{
    public class TipoFinanciamento: BaseEntity
    {
        public string Descricao { get; set; }
        public decimal Taxa { get; set; }
    }
}
