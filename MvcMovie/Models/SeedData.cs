using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2015-2-25"),
                        Genre = "Documentary",
                        Price = 7.99M,
                        Rating = "PG"
                    },

                    new Movie
                    {
                        Title = "The R.M.",
                        ReleaseDate = DateTime.Parse("2003-1-31"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "PG"

                    },

                    new Movie
                    {
                        Title = "The Other Side of Heaven",
                        ReleaseDate = DateTime.Parse("2002-4-12"),
                        Genre = "Drama",
                        Price = 9.99M,
                        Rating = "PG"
                    },

                    new Movie
                    {
                        Title = "The Singles Ward",
                        ReleaseDate = DateTime.Parse("2002-1-30"),
                        Genre = "Comedy",
                        Price = 3.99M,
                        Rating = "PG"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}