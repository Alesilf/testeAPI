using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Infra.Data.Repository
{
    public class TipoFinanciamentoRepository : ITipoFinanciamentoRepository
    {
        private readonly List<TipoFinanciamento> _tipoFinanciamentos;

        public TipoFinanciamentoRepository()
        {
            _tipoFinanciamentos = new List<TipoFinanciamento>();
            _tipoFinanciamentos.Add( new TipoFinanciamento() { Id = 1, Descricao = "Crédito Direto", Taxa = 2});
            _tipoFinanciamentos.Add( new TipoFinanciamento() { Id = 2, Descricao = "Crédito Consignado", Taxa = 1 });
            _tipoFinanciamentos.Add( new TipoFinanciamento() { Id = 3, Descricao = "Crédito Pessoa Jurídica", Taxa = 5 });
            _tipoFinanciamentos.Add( new TipoFinanciamento() { Id = 4, Descricao = "Crédito Pessoa Física", Taxa = 3 });
            _tipoFinanciamentos.Add( new TipoFinanciamento() { Id = 5, Descricao = "Crédito Imobiliário", Taxa = 9 });
        }

        public TipoFinanciamento BuscarPorId(int tipofinanciamento)
        {
            var ret = _tipoFinanciamentos.Where(x => x.Id == tipofinanciamento).FirstOrDefault();
            return ret;
        }
    }
}
