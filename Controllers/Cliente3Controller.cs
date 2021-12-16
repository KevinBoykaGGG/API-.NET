using ClassLibrary1.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.API.Controllers
{
    //en api se suele usar get, post, put, delete ....//
    [Route("api/[controller]")]
    [ApiController]
    public class Cliente3Controller : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public Cliente3Controller(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Clientes()
        {
            var clientes = await _clienteRepository.GetClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Cliente(int id)
        {
            var cliente = await _clienteRepository.GetClienteById(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Clientes(Cliente cliente)
        {
            await _clienteRepository.InsertCliente(cliente);
            return Ok("");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Clientes (int id)
        {
            await _clienteRepository.DeleteCliente(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Cliente (Cliente cliente)
        {
            await _clienteRepository.UpdateCliente(cliente);
            return Ok();
        }
    }
}
