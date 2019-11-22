using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uzduotis_Backend.Data;
using Uzduotis_Backend.Models;
using Microsoft.AspNetCore.Cors;

namespace Uzduotis_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly EntryContext _context;

        public CommentsController(EntryContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet("byentryid/{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int id)
        {
            return await _context.Comments.Where(x => x.EntryId == id).ToListAsync();
        }

        // POST: api/Comments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("byentryid/{id}")]
        public async Task<ActionResult<Comment>> PostComment(Comment comment, int id)
        {
            comment.Date = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_context.Entries.FindAsync(id) == null)
            {
                return BadRequest();
            }
            comment.EntryId = id;
            _context.Entries.Find(id).CommentsCount++;
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return Ok();
        }



        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
