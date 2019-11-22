using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uzduotis_Backend.Data;
using Uzduotis_Backend.Models;

namespace Uzduotis_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly EntryContext _context;

        public EntriesController(EntryContext context)
        {
            _context = context;
        }

        // GET: api/Entries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entry>>> GetEntries()
        {
            return await _context.Entries.ToListAsync();
        }

        // GET: api/Entries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> GetEntry(int id)
        {
            var entry = await _context.Entries.FindAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return entry;
        }



        // POST: api/Entries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Entry>> PostEntry(Entry entry)
        {
            entry.Date = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
                _context.Entries.Add(entry);
            await _context.SaveChangesAsync();

            return Ok();
        }


        private bool EntryExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }


    }
}

