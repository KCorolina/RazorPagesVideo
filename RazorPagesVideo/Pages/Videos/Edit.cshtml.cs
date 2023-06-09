using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesVideo.Data;
using RazorPagesVideo.Models;

namespace RazorPagesVideo.Pages.Videos
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesVideo.Data.RazorPagesVideoContext _context;

        public EditModel(RazorPagesVideo.Data.RazorPagesVideoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Video Video { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }

            var video =  await _context.Video.FirstOrDefaultAsync(m => m.Id == id);
            if (video == null)
            {
                return NotFound();
            }
            Video = video;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Video).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(Video.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VideoExists(int id)
        {
          return (_context.Video?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
