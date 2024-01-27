using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel.Cliente;
using Layer.Architecture.Domain.ViewModel.Financiamento;
using Layer.Architecture.Helper.Extension;
using Layer.Architecture.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Layer.Architecture.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanciamentoController : ControllerBase
    {
        private readonly IFinanciamentoService _financiamentoService;

        public FinanciamentoController(IFinanciamentoService FinanciamentoService)
        {
            _financiamentoService = FinanciamentoService;
        }

        /// <summary>
        /// Adicionar Financiamento
        /// </summary>
        /// <param name="financiamento"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFinanciamentoVM financiamento)
        {
            if (financiamento == null)
                return NotFound();
            financiamento.Cpf = financiamento.Cpf.SemFormatacaoCPF();
            var ret = await _financiamentoService.SimularFinanciamentoAsync(financiamento);
            return Ok(ret);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FinanciamentoVM financiamento)
        {
            if (financiamento == null)
                return NotFound();
            financiamento.Cpf = financiamento.Cpf.SemFormatacaoCPF();
            await _financiamentoService.Update(financiamento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            await _financiamentoService.Delete(id);

            return new NoContentResult();
        }

        /// <summary>
        /// Busca todos os Financiamentos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ret = await _financiamentoService.Get();
            return Ok(ret);
        }

        /// <summary>
        /// Busca financiamento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound();
            var ret = await _financiamentoService.GetById(id);
            return Ok(ret);
        }
    }
}
