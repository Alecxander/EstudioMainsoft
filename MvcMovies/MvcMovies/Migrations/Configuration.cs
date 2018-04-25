namespace MvcMovies.Migrations
{
    using MvcMovies.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcMovies.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MvcMovies.Models.MovieDBContext";
        }

        protected override void Seed(MvcMovies.Models.MovieDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Movies.AddOrUpdate(i => i.Title,
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-1-11"),
                    Genere = "Romantic Comedy",
                    Rating = "PG",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genere = "Comedy",
                    Rating = "PG",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genere = "Comedy",
                    Rating = "PG",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genere = "Western",
                    Rating = "PG",
                    Price = 3.99M
                });
        }
    }
}
