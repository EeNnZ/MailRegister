using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MailRegisterServer.Entities;

namespace MailRegisterServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly CompanyDbContext _context;
#if !DEBUG
        public MailsController(CompanyDbContext context)
        {
            _context = context;
        }
#else
        public MailsController()
        {
            _context = new CompanyDbContext();
        }
#endif
        // GET: api/Mails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mail>>> GetMail()
        {
          if (_context.Mail == null)
          {
              return NotFound();
          }
            return await _context.Mail.ToListAsync();
        }

        // GET: api/Mails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mail>> GetMail(int id)
        {
          if (_context.Mail == null)
          {
              return NotFound();
          }
            var mail = await _context.Mail.FindAsync(id);

            if (mail == null)
            {
                return NotFound();
            }

            return mail;
        }

        // PUT: api/Mails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMail(int id, Mail mail)
        {
            if (id != mail.Id)
            {
                return BadRequest();
            }

            _context.Entry(mail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MailExists(id))
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

        // POST: api/Mails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mail>> PostMail(Mail mail)
        {
          if (_context.Mail == null)
          {
              return Problem("Entity set 'CompanyDbContext.Mail'  is null.");
          }
            _context.Mail.Add(mail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMail", new { id = mail.Id }, mail);
        }

        // DELETE: api/Mails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMail(int id)
        {
            if (_context.Mail == null)
            {
                return NotFound();
            }
            var mail = await _context.Mail.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }

            _context.Mail.Remove(mail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MailExists(int id)
        {
            return (_context.Mail?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
