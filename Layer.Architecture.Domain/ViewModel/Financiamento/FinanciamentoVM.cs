using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Domain.ViewModel.Financiamento
{
    public class FinanciamentoVM
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public int TipoFinanciamento { get; set; }
        public decimal ValorFinancimento { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime? DataUltimoVencimento { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        public int Parcelas { get; set; }
        public string StatusFinancimento { get; set; }
    }
}
