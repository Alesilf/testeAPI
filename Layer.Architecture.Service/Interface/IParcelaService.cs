using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel.Parcela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Service.Interface
{
    public interface IParcelaService : IBaseService<Parcela>
    {
        Task Add(CreateParcelaVM inputModel);
        Task Delete(int id);
        Task<IEnumerable<ParcelaVM>> Get();
        Task<ParcelaVM> GetById(int id);
        Task Update(ParcelaVM inputModel);
    }
}
