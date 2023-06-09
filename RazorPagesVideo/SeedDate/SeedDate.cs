using Microsoft.EntityFrameworkCore;
using RazorPagesVideo.Data;
using RazorPagesVideo.Models;

namespace RazorPagesVideo.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesVideoContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesVideoContext>>()))
        {
            if (context == null || context.Video == null)
            {
                ArgumentNullException argumentNullException = new ArgumentNullException("Null RazorPagesVideoContext");
                throw argumentNullException;
            }

            // Look for any movies.
            if (context.Video.Any())
            {
                return;   // DB has been seeded
            }

            context.Video.AddRange(
                new Video
                {
                    Title = "Marry me",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Performer = "человек",
                    Price = 73,
                    
                },

                new Video
                {
                    Title = "свег",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Performer = "другой человек",
                    Price = 8.99m
                },

                new Video
                {
                    Title = "попкаморжа",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Performer = "ещеодинчеловек",
                    Price = 9.99m
                },

                new Video
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Performer = "Bittles",
                    Price = 3.99M            
                });

                if (context.Video.Any())
                {
                return;
                 }
            context.SaveChanges();
           
        }
    }
}