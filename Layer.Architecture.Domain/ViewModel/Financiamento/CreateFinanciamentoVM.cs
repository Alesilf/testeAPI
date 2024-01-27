using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Domain.ViewModel.Financiamento
{
    public class CreateFinanciamentoVM
    {
        public string Cpf { get; set; }
        public int TipoFinanciamento { get; set; }
        public decimal ValorFinancimento { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        public int Parcelas { get; set; }

    }
}
