using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Infra.Data.Context;
using Layer.Architecture.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Infra.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly MyContext _myContext;

        public ClienteRepository(MyContext myContext) : base(myContext)
        {
            _myContext = myContext;
        }
    }
}
