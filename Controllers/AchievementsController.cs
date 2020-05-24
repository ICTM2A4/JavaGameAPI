using JavaGameAPI.DTO.Achievements;
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
    public class AchievementsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AchievementsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Achievements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAchievement>>> GetAchievement()
        {
            var achievements = await _context.Achievement.ToListAsync();

            return achievements.Select(a => ConvertGetAchievementDTO(a)).ToList();
        }

        // GET: api/Achievements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAchievement>> GetAchievement(int id)
        {
            var achievement = await _context.Achievement.FindAsync(id);

            if (achievement == null)
            {
                return NotFound();
            }

            return ConvertGetAchievementDTO(achievement);
        }

        // PUT: api/Achievements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAchievement(int id, GetAchievement achievementDTO)
        {
            if (id != achievementDTO.ID)
            {
                return BadRequest();
            }

            var achievement = await _context.Achievement.FirstOrDefaultAsync(a => a.ID == id);

            if(achievement == null)
            {
                return BadRequest();
            }

            achievement.Name = achievementDTO.Name;
            achievement.Description = achievementDTO.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchievementExists(id))
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

        // POST: api/Achievements
        [HttpPost]
        public async Task<ActionResult<GetAchievement>> PostAchievement(GetAchievement achievementDTO)
        {
            var achievement = new Achievement()
            {
                Name = achievementDTO.Name,
                Description = achievementDTO.Description
            };

            _context.Achievement.Add(achievement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAchievement", new { id = achievement.ID }, ConvertGetAchievementDTO(achievement));
        }

        // DELETE: api/Achievements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Achievement>> DeleteAchievement(int id)
        {
            var achievement = await _context.Achievement.FindAsync(id);
            if (achievement == null)
            {
                return NotFound();
            }

            _context.Achievement.Remove(achievement);
            await _context.SaveChangesAsync();

            return achievement;
        }

        private bool AchievementExists(int id)
        {
            return _context.Achievement.Any(e => e.ID == id);
        }

        private GetAchievement ConvertGetAchievementDTO(Achievement achievement)
        {
            return new GetAchievement()
            {
                ID = achievement.ID,
                Name = achievement.Name,
                Description = achievement.Description
            };
        }
    }
}
