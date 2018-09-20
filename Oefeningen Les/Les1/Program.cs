using System.Linq;
using Model;
using System;

namespace Les1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MovieContext()) {

                /*//Adding a movie + actors to DB
                Movie m = new Movie {
                    Title = "No country for old men",
                    Actors = new System.Collections.Generic.List<MovieActor> {
                    new MovieActor{Actor = new Actor {Name = "Tommy Lee"}},
                    new MovieActor{Actor = new Actor {Name = "Xavier Berdem"}}
                    }
                };
                db.Movies.Add(m);
                db.SaveChanges();*/

                //Find and see the actors for each movie in DB
                foreach (var movie in db.Movies) {
                    Console.WriteLine("Found movie with title: " + movie.Title);
                    var MovieID = movie.Id;
                    //foreach (var movieActor in db.MovieActors.Where(ma => movie.Id == ma.MovieId)) {
                    //    foreach (var actor in db.Actors.Where(movie.Id == MovieActor.MovieId)) {
                    //        Console.WriteLine("Found actor with name: " + actor.Name);
                    //    }
                    //}
                    var query = db.Actors.Where(a => a.Movies.Any(m => m.MovieId == MovieID)).ToList();
                    var query1 = from actor in db.Actors where actor.Movies.Any(m => m.MovieId == MovieID) select actor;
                    Console.WriteLine(query1);


                    //foreach (var actor in db.Actors.Where(a => movie.Id == a.MovieId)) {
                    //    Console.WriteLine("Found actor with name: " + actor.Name);
                    //}
                }

                /*//Editing movie title name of the 1st movie in the DB
                Movie foundMovie = db.Movies.Find(1);
                Console.WriteLine("Found movie with title: " + foundMovie.Title);
                foundMovie.Title = "White cats, Black cats...";
                db.SaveChanges();
                Console.WriteLine("Title changed to: " + foundMovie.Title);*/   
            }
        }
    }
}
