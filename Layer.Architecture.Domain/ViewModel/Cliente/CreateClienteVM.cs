using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Domain.ViewModel.Cliente
{
    public class CreateClienteVM
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Uf { get; set; }
        public string Celular { get; set; }
    }
}
