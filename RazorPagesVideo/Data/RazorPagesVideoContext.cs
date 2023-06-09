using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesVideo.Models;

namespace RazorPagesVideo.Data
{
    public class RazorPagesVideoContext : DbContext
    {
        public RazorPagesVideoContext (DbContextOptions<RazorPagesVideoContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesVideo.Models.Video> Video { get; set; } = default!;
    }
}
