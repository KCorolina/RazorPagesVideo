using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesVideo.Data;
using RazorPagesVideo.Models;

namespace RazorPagesVideo.Pages.Videos
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesVideo.Data.RazorPagesVideoContext _context;

        public IndexModel(RazorPagesVideo.Data.RazorPagesVideoContext context)
        {
            _context = context;
        }

        public IList<Video> Video { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Performers { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? VideoPerformer { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Video != null)
            {
                IQueryable<string> performerQuery = from m in _context.Video
                                                orderby m.Performer
                                                select m.Performer;

                var movies = from m in _context.Video
                             select m;

                if (!string.IsNullOrEmpty(SearchString))
                {
                    movies = movies.Where(s => s.Title.Contains(SearchString));
                }

                if (!string.IsNullOrEmpty(VideoPerformer))
                {
                    movies = movies.Where(x => x.Performer == VideoPerformer);
                }
                Performers = new SelectList(await performerQuery.Distinct().ToListAsync());
                Video = await movies.ToListAsync();
            }
        }
    }
}
