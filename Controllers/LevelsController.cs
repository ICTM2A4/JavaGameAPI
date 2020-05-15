using JavaGameAPI.DTO.Levels;
using JavaGameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LevelsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Levels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetLevel>>> GetLevel()
        {
            var levels = await _context.Level.Include(l => l.Creator).ToListAsync();


            return levels.Select(l => ConvertGetLevelDTO(l)).ToList();
        }

        // GET: api/Levels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetLevel>> GetLevel(int id)
        {
            var level = await _context.Level
                .Include(l => l.Creator)
                .FirstOrDefaultAsync(l => l.ID == id);

            if (level == null)
            {
                return NotFound();
            }

            return ConvertGetLevelDTO(level);
        }

        // PUT: api/Levels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevel(int id, PostLevel levelDTO)
        {
            if (id != levelDTO.ID)
            {
                return BadRequest();
            }

            var level = await _context.Level.FirstOrDefaultAsync(l => l.ID == levelDTO.ID);

            level.Name = levelDTO.Name;
            level.Description = levelDTO.Description;
            level.Content = levelDTO.Content;
            level.Creator = await _context.User.FirstOrDefaultAsync(u => u.id == levelDTO.CreatorID);

            if (level.Creator == null)
            {
                // User of ScoredOn bestaan niet, bad request.
                return BadRequest();
            }

            _context.Entry(level).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelExists(id))
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

        // POST: api/Levels
        [HttpPost]
        public async Task<ActionResult<Level>> PostLevel(PostLevel levelDTO)
        {
            var level = new Level()
            {
                Name = levelDTO.Name,
                Description = levelDTO.Description,
                Content = levelDTO.Content,
                Creator = await _context.User.FirstOrDefaultAsync(u => u.id == levelDTO.CreatorID)
            };

            if (level.Creator == null)
            {
                // User of ScoredOn bestaan niet, bad request.
                return BadRequest();
            }

            _context.Level.Add(level);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLevel", new { id = level.ID }, ConvertGetLevelDTO(level));
        }

        // DELETE: api/Levels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Level>> DeleteLevel(int id)
        {
            var level = await _context.Level.FindAsync(id);
            if (level == null)
            {
                return NotFound();
            }

            _context.Level.Remove(level);
            await _context.SaveChangesAsync();

            return level;
        }

        private bool LevelExists(int id)
        {
            return _context.Level.Any(e => e.ID == id);
        }

        private GetLevel ConvertGetLevelDTO(Level level)
        {
            return new GetLevel()
            {
                ID = level.ID,
                Name = level.Name,
                Description = level.Description,
                Content = level.Content,
                CreatorID = level.Creator.id,
                CreatorUserName = level.Creator.UserName
            };
        }
    }
}
