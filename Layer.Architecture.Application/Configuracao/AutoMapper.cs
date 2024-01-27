using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Layer.Architecture.Domain.ViewModel.Cliente;
using Layer.Architecture.Domain.ViewModel.Financiamento;
using Layer.Architecture.Domain.ViewModel.Parcela;

namespace Layer.Architeture.Configuracao
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateClienteVM, Cliente>().ReverseMap();
            CreateMap<ClienteVM, Cliente>().ReverseMap();
            CreateMap<CreateFinanciamentoVM, Financiamento>().ReverseMap();
            CreateMap<FinanciamentoVM, Financiamento>().ReverseMap();
            CreateMap<CreateParcelaVM, Parcela>().ReverseMap();
            CreateMap<ParcelaVM, Parcela>().ReverseMap();
        }
    }
}
