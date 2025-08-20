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
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            return Ok(await _context.Projects.ToListAsync());
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = new Project
            {
                Name = model.Name,
                ClientId = model.ClientId,
                Status = model.Status,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                AssignedTeam = model.AssignedTeam
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] UpdateProjectDto updatedProjectDto)
        {
            var projectToUpdate = await _context.Projects.FindAsync(id);
            if (projectToUpdate == null)
            {
                return NotFound();
            }

           
            projectToUpdate.Name = updatedProjectDto.Name;
            projectToUpdate.ClientId = updatedProjectDto.ClientId;
            projectToUpdate.Status = updatedProjectDto.Status;
            projectToUpdate.StartDate = updatedProjectDto.StartDate;
            projectToUpdate.EndDate = updatedProjectDto.EndDate;
            projectToUpdate.AssignedTeam = updatedProjectDto.AssignedTeam;

            _context.Entry(projectToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
