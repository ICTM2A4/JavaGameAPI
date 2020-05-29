using JavaGameAPI.DTO;
using JavaGameAPI.Migrations;
using JavaGameAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ScoresController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Scores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetScore>>> GetScore([FromQuery(Name = "limit")] int? limit, [FromQuery(Name = "sort")] string sort, [FromQuery(Name = "uid")] int? uid, [FromQuery(Name = "lid")] int? lid)
        {
            var scores = await _context.Score
                .Include(s => s.User)
                .Include(s => s.ScoredOn)
                .ToListAsync();

            var scoresDTO = scores.Select(s => ConvertGetScoreDTO(s)).ToList();

            if(lid != null)
            {
                scoresDTO = scoresDTO.FindAll(s => s.ScoredOnID == lid);
            }

            if(sort == "ASC")
            {
                scoresDTO = scoresDTO.OrderBy(s => s.ScoreAmount).ToList();
            }
            else if(sort == "DESC")
            {
                scoresDTO = scoresDTO.OrderByDescending(s => s.ScoreAmount).ToList();
            }

            if(limit != null && limit > 0 && limit <= scoresDTO.Count())
            {
                scoresDTO = scoresDTO.GetRange(0, (int)limit);
            }

            if(uid != null)
            {
                scoresDTO = scoresDTO.FindAll(s => s.UserID == uid);
            }

            return scoresDTO;
        }

        // GET: api/Scores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetScore>> GetScore(int id)
        {
            var score = await _context.Score
                .Include(s => s.User)
                .Include(s => s.ScoredOn)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (score == null)
            {
                return NotFound();
            }

            return ConvertGetScoreDTO(score);
        }

        [HttpGet("topscores/{lid}")]
        public async Task<ActionResult<IEnumerable<GetScore>>> GetHighScores(int lid)
        {
            var highScoreGroup = await _context.Score
                .FromSqlRaw("SELECT ID, MAX(ScoreAmount) AS 'ScoreAmount', Timestamp, Userid, ScoredOnID from javagameapi.score WHERE ScoredOnID = " + lid +" GROUP BY UserID ORDER BY ScoreAmount DESC")
                .Include(s => s.ScoredOn)
                .Include(s => s.User)
                .ToListAsync();

            return highScoreGroup.Select(hs => ConvertGetScoreDTO(hs))
                                .OrderByDescending(s => s.ScoreAmount)
                                .ToList();
        }

        // PUT: api/Scores/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScore(int id, PostScore scoreDTO)
        {
            if (id != scoreDTO.ID)
            {
                return BadRequest();
            }

            var score = await _context.Score.FirstOrDefaultAsync(s => s.ID == scoreDTO.ID);

            score.ScoreAmount = scoreDTO.ScoreAmount;
            score.Timestamp = scoreDTO.Timestamp;
            score.User = await _context.User.FirstOrDefaultAsync(u => u.id == scoreDTO.UserID);
            score.ScoredOn = await _context.Level.FirstOrDefaultAsync(l => l.ID == scoreDTO.ScoredOnID);

            if (score.User == null || score.ScoredOn == null)
            {
                // User of ScoredOn bestaan niet, bad request.
                return BadRequest();
            }

            _context.Entry(score).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreExists(id))
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

        // POST: api/Scores
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(PostScore scoreDTO)
        {
            var score = new Score()
            {
                Timestamp = scoreDTO.Timestamp,
                ScoreAmount = scoreDTO.ScoreAmount,
                User = await _context.User.FirstOrDefaultAsync(u => u.id == scoreDTO.UserID),
                ScoredOn = await _context.Level.FirstOrDefaultAsync(s => s.ID == scoreDTO.ScoredOnID)
            };

            if(score.User == null || score.ScoredOn == null)
            {
                // User of ScoredOn bestaan niet, bad request.
                return BadRequest();
            }

            _context.Score.Add(score);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScore", new { id = score.ID }, ConvertGetScoreDTO(score));
        }

        // DELETE: api/Scores/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<GetScore>> DeleteScore(int id)
        {
            var score = await _context.Score
                 .Include(s => s.User)
                 .Include(s => s.ScoredOn)
                 .FirstOrDefaultAsync(s => s.ID == id);

            if (score == null)
            {
                return NotFound();
            }

            _context.Score.Remove(score);
            await _context.SaveChangesAsync();

            return ConvertGetScoreDTO(score);
        }

        private bool ScoreExists(int id)
        {
            return _context.Score.Any(e => e.ID == id);
        }

        private GetScore ConvertGetScoreDTO(Score score)
        {
            return new GetScore()
            {
                ID = score.ID,
                ScoreAmount = score.ScoreAmount,
                Timestamp = score.Timestamp,
                UserID = score.User.id,
                UserName = score.User.UserName,
                ScoredOnID = score.ScoredOn.ID,
                ScoredOnName = score.ScoredOn.Name
            };
        }
    }
}
