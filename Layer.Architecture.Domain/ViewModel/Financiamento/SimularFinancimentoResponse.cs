using Layer.Architecture.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Domain.ViewModel.Financiamento
{
    public class SimularFinancimentoResponse
    {
        public int IdFinanciamento { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorJuros { get; set; }
        public string StatusFinanciamento { get; set; }
        public List<string> Erro { get; set; }
    }
}
