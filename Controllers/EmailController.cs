using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mba.apiref;

namespace APIEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly DataContext _context;

        public EmailController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Email
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetEmails()
        {
          if (_context.Emails == null)
          {
              return NotFound();
          }
            return await _context.Emails.ToListAsync();
        }

        // GET: api/Email/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Email>> GetEmail(string id)
        {
          if (_context.Emails == null)
          {
              return NotFound();
          }
            var email = await _context.Emails.FindAsync(id);

            if (email == null)
            {
                return NotFound();
            }

            return email;
        }

        // PUT: api/Email/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmail(string id, Email email)
        {
            if (id != email.email)
            {
                return BadRequest();
            }

            _context.Entry(email).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
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

        // POST: api/Email
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Email>> PostEmail(Email email)
        {
          if (_context.Emails == null)
          {
              return Problem("Entity set 'DataContext.Emails'  is null.");
          }
            _context.Emails.Add(email);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmailExists(email.email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmail", new { id = email.email }, email);
        }

        // DELETE: api/Email/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmail(string id)
        {
            if (_context.Emails == null)
            {
                return NotFound();
            }
            var email = await _context.Emails.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }

            _context.Emails.Remove(email);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailExists(string id)
        {
            return (_context.Emails?.Any(e => e.email == id)).GetValueOrDefault();
        }
    }
}
