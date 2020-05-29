using JavaGameAPI.DTO.Achievements;
using JavaGameAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGeneration;
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
        public async Task<ActionResult<IEnumerable<GetAchievement>>> GetAchievement([FromQuery] int? uid)
        {
            var achievements = await _context.Achievement.Include(a => a.UserAchievements).ToListAsync();

            if(uid != null)
            {
                achievements = achievements.Where(a => a.UserAchievements.Any(ua => ua.UserID == uid)).ToList();
            }

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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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

        [Authorize]
        [HttpPost("user")]
        public async Task<ActionResult> PostAchievementToUser(GetUserAchievement userAchievementDTO)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.id == userAchievementDTO.UserID);
            var achievement = await _context.Achievement.FirstOrDefaultAsync(a => a.ID == userAchievementDTO.AchievementID);

            if(user == null || achievement == null)
            {
                return BadRequest();
            }

            var userAchievement = new UserAchievement()
            {
                AchievementID = achievement.ID,
                Achievement = achievement,
                UserID = user.id,
                User = user
            };

            _context.UserAchievement.Add(userAchievement);
            await _context.SaveChangesAsync();

            return Ok(userAchievementDTO);
        }

        [Authorize]
        [HttpDelete("user")]
        public async Task<ActionResult> DeleteAchievementFromUser(GetUserAchievement userAchievementDTO)
        {
            var userAchiement = await _context.UserAchievement
                .FirstOrDefaultAsync(
                ua =>
                ua.AchievementID == userAchievementDTO.AchievementID &&
                ua.UserID == userAchievementDTO.UserID);

            if(userAchiement == null)
            {
                return BadRequest();
            }

            _context.UserAchievement.Remove(userAchiement);
            await _context.SaveChangesAsync();

            return Ok();
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
