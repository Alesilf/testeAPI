using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel.Financiamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Service.Interface
{
    public interface IFinanciamentoService : IBaseService<Financiamento>
    {
        Task Add(CreateFinanciamentoVM inputModel);
        Task Delete(int id);
        Task<IEnumerable<FinanciamentoVM>> Get();
        Task<FinanciamentoVM> GetById(int id);
        Task Update(FinanciamentoVM inputModel);
        Task<SimularFinancimentoResponse> SimularFinanciamentoAsync(CreateFinanciamentoVM financiamentoRequest);
    }
}
