using System;

namespace Layer.Architecture.Domain.Entities
{
    public class Financiamento: BaseEntity
    {
        public string Cpf { get; set; }
        public int TipoFinanciamento { get; set; }
        public decimal ValorFinancimento { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime? DataUltimoVencimento { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        public int Parcelas { get; set; }
        public string StatusFinanciamento { get; set; }
    }
}
