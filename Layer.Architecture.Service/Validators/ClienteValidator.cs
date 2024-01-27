using FluentValidation;
using Layer.Architecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Layer.Architecture.Service.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("Preencha o campo Nome.")
                    .NotNull().WithMessage("Preencha o campo Nome.");

            RuleFor(c => c.Cpf)
                    .NotEmpty().WithMessage("Preencha o campo CPF.")
                    .NotNull().WithMessage("Preencha o campo CPF.")
                    .Length(11).WithMessage("Preencha o campo CPF valido.")
                    .When(c => c.Cpf.Length > 11 || !Regex.IsMatch(c.Cpf, "^[0-9]+$")).WithMessage("Preencha o campo CPF valido.");

            RuleFor(c => c.Celular)
                    .NotEmpty().WithMessage("Preencha o campo Celular.")
                    .NotNull().WithMessage("Preencha o campo Celular.")
                    .Length(11).WithMessage("Preencher apenas com DDD e Numero")
                    .When(c => c.Celular.Length > 11 || !Regex.IsMatch( c.Celular, "^[0-9]+$")).WithMessage("Preencher apenas com DDD e Numero");
            
            RuleFor(c => c.Uf)
                    .NotEmpty().WithMessage("Preencha o campo UF.")
                    .NotNull().WithMessage("Preencha o campo UF.")
                    .Length(11).WithMessage("Preencher apenas com sigla do estado")
                    .When(c => c.Uf.Length > 2 || !Regex.IsMatch(c.Uf, "[a-zA-Z]")).WithMessage("Preencher apenas com sigla do estado");
        }
    }
}