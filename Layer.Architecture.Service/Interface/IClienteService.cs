using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Service.Interface
{
    public interface IClienteService : IBaseService<Cliente>
    {
        Task Add(CreateClienteVM inputModel);
        Task Delete(int id);
        Task<IEnumerable<ClienteVM>> Get();
        Task<ClienteVM> GetById(int id);
        Task Update(ClienteVM inputModel);
    }
}
