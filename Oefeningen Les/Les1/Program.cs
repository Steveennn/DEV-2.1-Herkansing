using System.Linq;
using Model;
using System;
using System.Collections.Generic;

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

                //FEEDBACK VAN LES
                foreach (var movie in db.Movies) {
                    Console.WriteLine(movie.Title);
                    foreach (var ma in db.MovieActor) {
                        if (ma.MovieId == movie.Id) {
                            foreach (var actor in db.Actors) {
                                if (actor.Id == ma.ActorId) {
                                    Console.WriteLine(" - " + actor.Name);
                                }
                            }
                        }
                    }
                }
                var query = from m in db.Movies
                            from ma in db.MovieActor
                            from a in db.Actors
                            where m.Id == ma.MovieId && a.Id == ma.ActorId
                            select new {Actor = a, Movie = m};
                            //where m.Title.EndsWith("2")
                            //select m;
                foreach (var item in query){

                    Console.WriteLine("Movies: " + item.Movie.Title + " - Actor: " + item.Actor.Name);
                }


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
                    return result.Where(a => a.Movies.Any(m => m.Movie == MovieId));
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
