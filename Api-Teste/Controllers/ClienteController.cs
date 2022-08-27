using Api_Teste.Authentication;
using Api_Teste.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly DbClienteContext _context;

        public ClienteController(DbClienteContext context)
        {
            _context = context;
        }

        public ClienteController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
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
        public async Task<IActionResult> Create([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response 
                { 
                    Status = "Error", Message = "Usuário já existe!" 
                });
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = "Error",
                    Message = "Erro na criação do usuário. Tente novamente"
                });
            
            return Ok(new Response { Status = "Sucess", Message = "Usuário criado." });
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
