using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Model {
    public class MovieContext : DbContext {
        //this is actual entity object linked to the movies in our DB
        public DbSet<Movie> Movies { get; set; }
        //this is actual entity object linked to the actors in our DB
        public DbSet<Actor> Actors { get; set; }

        //this method is run automatically by EF the first time we run the application
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //here we define the name of our database
            optionsBuilder.UseNpgsql("User ID=postgres;Password=steven;Host=localhost;Port=5432;Database=MovieDB;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<MovieActor>().HasKey(t => new { t.ActorId, t.MovieId });
            modelBuilder.Entity<MovieActor>().HasOne(ma => ma.Movie).WithMany(m => m.Actors).HasForeignKey(ma => ma.MovieId);
            modelBuilder.Entity<MovieActor>().HasOne(ma => ma.Actor).WithMany(m => m.Movies).HasForeignKey(ma => ma.ActorId);
        }
    }

    //this is the typed representation of a movie in our project
    public class Movie {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<MovieActor> Actors { get; set; }
    }

    //this is the typed representation of an actor in our project
    public class Actor {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<MovieActor> Movies { get; set; }
    }

    //this is the typed representation of our join table mapping a movie with an actor
    public class MovieActor {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}