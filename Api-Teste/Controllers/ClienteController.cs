using Api_Teste.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Api_Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DbClienteContext _context;

        public ClienteController(DbClienteContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/listar")]
        public IEnumerable<Cliente> Listar()
        {
            return _context.clientes.ToList();
        }
        [HttpGet("{id}")]
        public IEnumerable<Cliente> ProcurarPorId(int id)
        {
            return _context.clientes.Where(s => s.IdCliente == id);
        }
        [HttpPost]
        [Route("/cadastrar")]
        public IActionResult Create(Cliente cliente)
        {
            if(cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }
            else
            {
                _context.clientes.Add(cliente);
                _context.SaveChanges();
                return Ok();
            }
            
        }
        [HttpPut]
        [Route("/atualizar")]
        public void Update(Cliente cliente)
        { 
            
            
                _context.clientes.Update(cliente);
                _context.SaveChanges();
                
            
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Cliente cliente)
        {
            if(cliente==null)
            {
               return BadRequest();
            }
            else
            {
                _context.clientes.Remove(cliente);
                _context.SaveChanges();
                return Ok();
            }
            
        }
    }
}
