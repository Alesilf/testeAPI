using Layer.Architecture.Domain.ViewModel.Parcela;
using Layer.Architecture.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Layer.Architecture.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelaController : ControllerBase
    {
        private readonly IParcelaService _ParcelaService;

        public ParcelaController(IParcelaService ParcelaService)
        {
            _ParcelaService = ParcelaService;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="Parcela"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateParcelaVM Parcela)
        {
            if (Parcela == null)
                return NotFound();

            await _ParcelaService.Add(Parcela);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ParcelaVM Parcela)
        {
            if (Parcela == null)
                return NotFound();

            await _ParcelaService.Update(Parcela);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            await _ParcelaService.Delete(id);

            return new NoContentResult();
        }

        /// <summary>
        /// Busca todos Usurios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ret = await _ParcelaService.Get();
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
            var ret = await _ParcelaService.GetById(id);
            return Ok(ret);
        }
    }
}
