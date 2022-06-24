using Microsoft.AspNetCore.Mvc;
using NudeApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NudeApp.Data;
using System;

namespace NudeApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HighValueItemController : Controller
    {
        private readonly NudeAppContext _context;
        private readonly UserRepository _userRepository;

        public HighValueItemController(NudeAppContext context, UserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        // GET: api/HighValueItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HighValueItem>>> GetHighValueItems()
        {
            IEnumerable<HighValueItem> highValueItems = _userRepository.GetAll();

            Task<ActionResult<IEnumerable<HighValueItem>>> task = Task.Run<ActionResult<IEnumerable<HighValueItem>>>(()=> Ok(_userRepository.GetAll()));

            return Ok(_userRepository.GetAll());
            //return await _context.HighValueItem.ToListAsync();
        }

        // GET: api/HighValueItem/id
        [HttpGet("{id}")]
        public async Task<ActionResult<HighValueItem>> GetHighValueItem(int id)
        {
            var note = await _context.HighValueItem.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        // PUT: api/HighValueItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHighValueItem(Guid id, HighValueItem highValueItem)
        {
            if (id != highValueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(highValueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HighValueItemExists(id))
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

        // POST: api/HighValueItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HighValueItem>> CreateHighValueItem(HighValueItem highValueItem)
        {
            _context.HighValueItem.Add(highValueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHighValueItem", new { id = highValueItem.Id }, highValueItem);
        }

        // DELETE: api/HighValueItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHighValueItem(int id)
        {
            var note = await _context.HighValueItem.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _context.HighValueItem.Remove(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HighValueItemExists(Guid id)
        {
            return _context.HighValueItem.Any(e => e.Id == id);
        }
    }
}