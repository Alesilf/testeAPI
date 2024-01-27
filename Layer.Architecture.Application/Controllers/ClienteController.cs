using FluentValidation.Validators;
using Layer.Architecture.Domain.ViewModel.Cliente;
using Layer.Architecture.Helper.Extension;
using Layer.Architecture.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Layer.Architecture.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClienteVM cliente)
        {
            try
            {
                if (cliente == null)
                    return NotFound();
                cliente.Cpf = cliente.Cpf.SemFormatacaoCPF();
                await _clienteService.Add(cliente);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400,ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClienteVM cliente)
        {
            if (cliente == null)
                return NotFound();
            cliente.Cpf = cliente.Cpf.SemFormatacaoCPF();
            await _clienteService.Update(cliente);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            await _clienteService.Delete(id);

            return new NoContentResult();
        }

        /// <summary>
        /// Busca todos Usurios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ret = await _clienteService.Get();
            return Ok(ret);
        }

        /// <summary>
        /// Busca usuario por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound();
            var ret = await _clienteService.GetById(id);
            return Ok(ret);
        }
    }
}
