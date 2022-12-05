using JediAPI.Data;
using JediAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace JediAPI.Controllers
{
    [ApiController] // Defines this as a API Controller and not a MVC Controller
    [Route("api/[controller]")]
    public class JediController : Controller
    {
        private readonly JediAPIDbContext dbContext;
        public JediController(JediAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllJedi(string? jediRankFilter = "", string? jediOwnerFilter = "", string? sortType = "asc") //string filter = "", string filterValue = "", string sortType = ""
        {
            if (!string.IsNullOrEmpty(jediRankFilter))
                jediRankFilter = jediRankFilter.ToLower();
            if (!string.IsNullOrEmpty(jediOwnerFilter))
                jediOwnerFilter = jediOwnerFilter.ToLower();
            if (!string.IsNullOrEmpty(sortType))
                sortType = sortType.ToLower();

            var jedi = await dbContext.JediNotes.ToListAsync();

            if (!string.IsNullOrEmpty(jediRankFilter))
            {
                if (jediRankFilter == "padawan" || jediRankFilter == "knight" || jediRankFilter == "master")
                    jedi = jedi.FindAll(p => p.JediRank.ToLower() == jediRankFilter);
                else
                {
                    jedi = new List<JediNote>();
                    return Ok("jediRankFilter value must be \"Padawan\", \"Knight\", or \"Master\"");
                }
            }
            if (!string.IsNullOrEmpty(jediOwnerFilter))
            {
                jedi = jedi.FindAll(p => p.Owner.ToLower() == jediOwnerFilter);
            }
            if (sortType == "asc")
            {
                jedi = jedi.OrderBy(jedi => jedi.Created).ToList();
            } else if (sortType == "desc")
            {
                jedi = jedi.OrderByDescending(jedi => jedi.Created).ToList();
            }

            if (jedi.Count > 0)
                return Ok(jedi);
            else
                return Ok("The are no jedi notes found.");
        }

        [HttpPost]
        public async Task<IActionResult> AddJedi(AddJediRequest addJediRequest)
        {
            if (addJediRequest.JediRank == "Master" || addJediRequest.JediRank == "Knight" || addJediRequest.JediRank == "Padawan")
            {
                JediNote jedi = new JediNote()
                {
                    Title = addJediRequest.Title,
                    Body = addJediRequest.Body,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Owner = addJediRequest.Owner,
                    JediRank = addJediRequest.JediRank.ToString()
                };

                await dbContext.JediNotes.AddAsync(jedi);

                await dbContext.SaveChangesAsync();

                return Ok(jedi);
            }
            else
            {
                return BadRequest("Jedi Rank Not Valid");
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteJedi([FromRoute] Guid id)
        {
            JediNote jedi = await dbContext.JediNotes.FindAsync(id);

            if (jedi != null)
            {
                dbContext.JediNotes.Remove(jedi);
                await dbContext.SaveChangesAsync();

                return Ok(string.Format("Jedi note with id {0} has been deleted.", id));
            }
            else
            {
                return NotFound(string.Format("Jedi note with id {0} does not exist.", id));
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateJedi([FromRoute] Guid id, UpdateJediRequest updateJediRequest)
        {
            JediNote jedi = await dbContext.JediNotes.FindAsync(id);

            if (jedi != null)
            {
                jedi.Title = updateJediRequest.Title;
                jedi.Body = updateJediRequest.Body;
                jedi.Owner= updateJediRequest.Owner;
                jedi.JediRank = updateJediRequest.JediRank;
                jedi.Updated = DateTime.Now;

                await dbContext.SaveChangesAsync();

                return Ok("Jedi note has been updated");
            } else
            {
                return NotFound();
            }
        }
    }
}
