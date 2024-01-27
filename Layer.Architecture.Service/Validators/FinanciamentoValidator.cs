using FluentValidation;
using Layer.Architecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Service.Validators
{
    public class FinanciamentoValidator : AbstractValidator<Financiamento>
    {
        public FinanciamentoValidator()
        {
            RuleFor(c => c.Cpf)
                    .NotEmpty().WithMessage("Preencha o campo Cpf.")
                    .NotNull().WithMessage("Preencha o campo Cpf.");

            RuleFor(c => c.TipoFinanciamento)
                    .NotEmpty().WithMessage("Preencha o campo TipoFinanciamento.")
                    .NotNull().WithMessage("Preencha o campo TipoFinanciamento.");

            RuleFor(c => c.ValorTotal)
                    .NotEmpty().WithMessage("Preencha o campo ValorTotal.")
                    .NotNull().WithMessage("Preencha o campo ValorTotal.");

            RuleFor(c => c.DataPrimeiroVencimento)
                    .NotEmpty().WithMessage("Preencha o campo DataPrimeiroVencimento.")
                    .NotNull().WithMessage("Preencha o campo DataPrimeiroVencimento.");


            RuleFor(c => c.Parcelas)
                    .NotEmpty().WithMessage("Preencha o campo Parcelas.")
                    .NotNull().WithMessage("Preencha o campo Parcelas.");
        }
    }
}
