using FluentValidation;
using Layer.Architecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Service.Validators
{
    public class ParcelaValidator : AbstractValidator<Parcela>
    {
        public ParcelaValidator()
        {
            RuleFor(c => c.IdFinanciamento)
                .NotEmpty().WithMessage("Preencha o campo IdFinanciamento.")
                .NotNull().WithMessage("Preencha o campo IdFinanciamento.");

            RuleFor(c => c.NumeroParcela)
                    .NotEmpty().WithMessage("Preencha o campo NumeroParcela.")
                    .NotNull().WithMessage("Preencha o campo NumeroParcela.");

            RuleFor(c => c.ValorParcela)
                    .NotEmpty().WithMessage("Preencha o campo ValorParcela.")
                    .NotNull().WithMessage("Preencha o campo ValorParcela.");

            RuleFor(c => c.DataVencimento)
                    .NotEmpty().WithMessage("Preencha o campo DataVencimento.")
                    .NotNull().WithMessage("Preencha o campo DataVencimento.");
        }
    }
}
