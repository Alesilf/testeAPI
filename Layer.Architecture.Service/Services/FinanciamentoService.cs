using AutoMapper;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel.Financiamento;
using Layer.Architecture.Infra.Data.Interface;
using Layer.Architecture.Service.Interface;
using Layer.Architecture.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Service.Services
{
    public class FinanciamentoService : BaseService<Financiamento>, IFinanciamentoService
    {
        private readonly IFinanciamentoRepository _financiamentoRepository;
        private readonly ITipoFinanciamentoRepository _tipoFinanciamentoRepository;
        private readonly IParcelaRepository _parcelaRepository;

        private readonly IMapper _mapper;

        public FinanciamentoService(IFinanciamentoRepository financiamentoRepository, IParcelaRepository parcelaRepository, ITipoFinanciamentoRepository tipoFinanciamentoRepository, IMapper mapper)
        {
            _financiamentoRepository = financiamentoRepository;
            _mapper = mapper;
            _tipoFinanciamentoRepository = tipoFinanciamentoRepository;
            _parcelaRepository = parcelaRepository;
        }


        public async Task Add(CreateFinanciamentoVM inputModel)
        {
            var entity = _mapper.Map<Financiamento>(inputModel);

            Validate(entity, Activator.CreateInstance<FinanciamentoValidator>());
            await _financiamentoRepository.Insert(entity);
        }

        public async Task Delete(int id) => await _financiamentoRepository.Delete(id);

        public async Task<IEnumerable<FinanciamentoVM>> Get()
        {
            var entities = await _financiamentoRepository.Select();

            var outputModels = entities.Select(s => _mapper.Map<FinanciamentoVM>(s));

            return outputModels;
        }

        public async Task<FinanciamentoVM> GetById(int id)
        {
            var entity = await _financiamentoRepository.Select(id);

            var outputModel = _mapper.Map<FinanciamentoVM>(entity);

            return outputModel;
        }

        public async Task Update(FinanciamentoVM inputModel)
        {
            var entity = _mapper.Map<Financiamento>(inputModel);
            var FinanciamentoDB = await _financiamentoRepository.Select(inputModel.Id);
            if (FinanciamentoDB == null)
            {
                throw new Exception("Financiamento Inválida");
            };
            Validate(entity, Activator.CreateInstance<FinanciamentoValidator>());
            await _financiamentoRepository.Update(entity);
        }

        public async Task<SimularFinancimentoResponse> SimularFinanciamentoAsync(CreateFinanciamentoVM financiamentoRequest)
        {
            _ = financiamentoRequest ?? throw new ArgumentNullException(nameof(financiamentoRequest));
            var financiamento = _mapper.Map<Financiamento>(financiamentoRequest);
            var ret = new SimularFinancimentoResponse();
            List<string> erro = new List<string>();
            if(financiamento.TipoFinanciamento < 0 || financiamento.TipoFinanciamento > 5)
            {
                erro.Add("Tipo de financiamento inválido.");
            }

            if (financiamento.TipoFinanciamento == 3 && financiamento.ValorFinancimento < 15000)
            {
                erro.Add("Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00.");
            }

            if (financiamento.ValorTotal > 1000000)
            {
                erro.Add("O valor máximo a ser liberado para qualquer tipo de empréstimo é de R$ 1.000.000,00.");

            }

            if (financiamento.DataPrimeiroVencimento < DateTime.Now.AddDays(15).Date || financiamento.DataPrimeiroVencimento > DateTime.Now.AddDays(40).Date)
            {
                erro.Add("A data do primeiro vencimento sempre será no mínimo 15 dias e no máximo 40 dias a partir da data atual.");
            }

            if (financiamento.Parcelas < 5 || financiamento.Parcelas > 72)
            {
                erro.Add("A quantidade mínima de parcelas é de 5x e máxima de 72x.");
            }

            if (erro.Any())
            {
                financiamento.StatusFinanciamento = "Reprovado";
                ret.Erro = erro;
            }

            else
            {
                financiamento.StatusFinanciamento = "Aprovado";
            }

            var tipofinanciamento = _tipoFinanciamentoRepository.BuscarPorId(financiamentoRequest.TipoFinanciamento);
            decimal valor = 0;
            if (financiamento.Parcelas > 0)
            {
                valor = (decimal)(Math.Pow((double)(1 + tipofinanciamento.Taxa / 100), financiamento.Parcelas) * decimal.ToDouble(financiamento.ValorFinancimento));
            }
            financiamento.ValorTotal = valor;
            financiamento.DataUltimoVencimento = financiamento.DataPrimeiroVencimento.AddMonths(financiamento.Parcelas - 1);
            financiamento = await _financiamentoRepository.Insert(financiamento);
            var valorParcela = financiamento.Parcelas > 0 ? financiamento.ValorTotal / financiamento.Parcelas : 0;
            if (financiamento.StatusFinanciamento != "Reprovado")
            {
                for (var i = 0; i < financiamento.Parcelas; i++)
                {
                    var parcela = new Parcela()
                    {
                        IdFinanciamento = financiamento.Id,
                        NumeroParcela = i + 1,
                        ValorParcela = valorParcela,
                        DataVencimento = financiamento.DataPrimeiroVencimento.AddMonths(i)
                    };
                    await _parcelaRepository.Insert(parcela);
                }
            }

            ret.IdFinanciamento = financiamento.Id;
            ret.ValorTotal = financiamento.ValorTotal;
            ret.ValorJuros = financiamento.ValorTotal - financiamento.ValorFinancimento;
            ret.StatusFinanciamento = financiamento.StatusFinanciamento;
            return ret;

        }
    }
}
