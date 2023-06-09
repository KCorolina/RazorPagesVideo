using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesVideo.Data;
using RazorPagesVideo.Models;

namespace RazorPagesVideo.Pages.Videos
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesVideo.Data.RazorPagesVideoContext _context;

        public DeleteModel(RazorPagesVideo.Data.RazorPagesVideoContext context)
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

            var video = await _context.Video.FirstOrDefaultAsync(m => m.Id == id);

            if (video == null)
            {
                return NotFound();
            }
            else 
            {
                Video = video;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }
            var video = await _context.Video.FindAsync(id);

            if (video != null)
            {
                Video = video;
                _context.Video.Remove(Video);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
