using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EFDataLibrary.DataAccess;
using EFDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EFMatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchOddsController : ControllerBase
    {
        private readonly MatchContext _context;

        public MatchOddsController(MatchContext context)
        {
            _context = context;
        }

        // GET: api/MatchOdds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchOdds>>> GetMatchOdds()
        {
            return await _context.MatchOdds.ToListAsync();
        }


        // GET: api/MatchOdds/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchOdds>> GetMatchOdds(int id)
        {
            var matchOdds = await _context.MatchOdds.FindAsync(id);

            if (matchOdds == null)
            {
                return NotFound();
            }
            //matchOdds.Match.ign
            return matchOdds;
        }

        // PUT: api/MatchOdds/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatchOdds(int id, MatchOdds matchOdds)
        {
            if (id != matchOdds.ID)
            {
                return BadRequest();
            }

            _context.Entry(matchOdds).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchOddsExists(id))
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

        // POST: api/MatchOdds
        [HttpPost]
        public async Task<ActionResult<MatchOdds>> PostMatchOdds(MatchOdds MatchOdds)
        {
            var matchWithSpecifier = _context.MatchOdds.Where(x => x.MatchId == MatchOdds.MatchId && x.Specifier==MatchOdds.Specifier).FirstOrDefault();

            if (matchWithSpecifier != null)
            {
                throw new DataException("Specifier for this match Odds already exists. Please Use Put method to alter it");
            }

            _context.MatchOdds.Add(MatchOdds);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatchOdds", new { id = MatchOdds.ID }, MatchOdds);
        }

        // DELETE: api/MatchOdds/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatchOdds(int id)
        {
            var matchOdd = await _context.MatchOdds.FindAsync(id);
            if (matchOdd == null)
            {
                return NotFound();
            }
            _context.MatchOdds.Remove(matchOdd);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatchOddsExists(int id)
        {
            return _context.MatchOdds.Any(e => e.ID == id);
        }
    }
}

