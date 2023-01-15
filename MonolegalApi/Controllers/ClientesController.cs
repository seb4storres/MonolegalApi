using Microsoft.AspNetCore.Mvc;
using MonolegalApi.Models;
using MonolegalApi.Services;

namespace MonolegalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly ClientesService _clientesService;

        public ClientesController(ClientesService clientesService) =>
            _clientesService = clientesService;

        [HttpGet]
        public async Task<List<Cliente>> Get() =>
            await _clientesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Cliente>> Get(string id)
        {
            var cliente = await _clientesService.GetAsync(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente newCliente)
        {
            await _clientesService.CreateAsync(newCliente);

            return CreatedAtAction(nameof(Get), new { id = newCliente.Id }, newCliente);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Cliente updatedCliente)
        {
            var cliente = await _clientesService.GetAsync(id);

            if (cliente is null)
            {
                return NotFound();
            }

            updatedCliente.Id = cliente.Id;

            await _clientesService.UpdateAsync(id, updatedCliente);

            return Content("Se enviara un email donde tiene el mensaje: usted se encontraba en primer recordatorio de pago, su estado ahora es Segundo recordatorio, se pide hacer el pago oportuno");
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var cliente = await _clientesService.GetAsync(id);

            if (cliente is null)
            {
                return NotFound();
            }

            await _clientesService.RemoveAsync(id);

            return NoContent();
        }
    }
}
