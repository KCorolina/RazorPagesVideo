using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesVideo.Data;
using RazorPagesVideo.Models;

namespace RazorPagesVideo.Pages.Videos
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesVideo.Data.RazorPagesVideoContext _context;

        public CreateModel(RazorPagesVideo.Data.RazorPagesVideoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Video Video { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Video == null || Video == null)
            {
                return Page();
            }

            _context.Video.Add(Video);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
