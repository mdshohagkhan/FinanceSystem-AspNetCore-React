using FinancialManagementSystems.Data;
using FinancialManagementSystems.Models.DTOs;
using FinancialManagementSystems.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialManagementSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = new Client
            {
                Name = model.Name,
                Email = model.Email,
                Company = model.Company,
                Phone = model.Phone,
                Password = model.Password 
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

       
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            return Ok(await _context.Clients.ToListAsync());
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] UpdateClientDto updatedClientDto)
        {
            var clientToUpdate = await _context.Clients.FindAsync(id);

            if (clientToUpdate == null)
            {
                return NotFound();
            }

            
            clientToUpdate.Name = updatedClientDto.Name;
            clientToUpdate.Email = updatedClientDto.Email;
            clientToUpdate.Company = updatedClientDto.Company;
            clientToUpdate.Phone = updatedClientDto.Phone;

            _context.Entry(clientToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
