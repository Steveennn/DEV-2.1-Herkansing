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
                    Title = "The Lion King",
                    Actors = new System.Collections.Generic.List<MovieActor> {
                    new MovieActor{Actor = new Actor {Name = "Timon"}},
                    new MovieActor{Actor = new Actor {Name = "Pumba"}},
                    new MovieActor{Actor = new Actor {Name = "Simba"}}
                    }
                };
                Movie m1 = new Movie {
                    Title = "Marvel's Avengers",
                    Actors = new System.Collections.Generic.List<MovieActor> {
                    new MovieActor{Actor = new Actor {Name = "Robert Downey Jr"}},
                    new MovieActor{Actor = new Actor {Name = "Chris Hemsworth"}},
                    new MovieActor{Actor = new Actor {Name = "Chris Evans"}}
                    }
                };
                Movie m2 = new Movie {
                    Title = "Thor",
                    Actors = new System.Collections.Generic.List<MovieActor> {
                    new MovieActor{Actor = new Actor {Name = "Chris Hemsworth"}}
                    }
                };
                Movie m3 = new Movie {
                    Title = "Black Panther",
                    Actors = new System.Collections.Generic.List<MovieActor> {
                    new MovieActor{Actor = new Actor {Name = "Chadwick Boseman"}},
                    new MovieActor{Actor = new Actor {Name = "Chris Evans"}}
                    }
                };
                Movie m4 = new Movie {
                    Title = "No country for old men",
                    Actors = new System.Collections.Generic.List<MovieActor> {
                        new MovieActor{Actor = new Actor {Name = "Tommy Lee"}},
                        new MovieActor{Actor = new Actor {Name = "Xavier Berdem"}}
                    }
                };
                
                db.Movies.Add(m);
                db.Movies.Add(m1);
                db.Movies.Add(m2);
                db.Movies.Add(m3);
                db.Movies.Add(m4);
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
                foreach (var actor in db.Actors) {
                    Console.WriteLine(actor.Name);
                    foreach (var ma in db.MovieActor) {
                        if (ma.ActorId == actor.Id) {
                            foreach (var movie in db.Movies) {
                                if (movie.Id == ma.MovieId) {
                                    Console.WriteLine(" - " + movie.Title);
                                }
                            }
                        }
                    }
                }
                /*var query = from m in db.Movies
                            from ma in db.MovieActor
                            from a in db.Actors
                            where m.Id == ma.MovieId && a.Id == ma.ActorId
                            select new {Actor = a, Movie = m};
                            //where m.Title.EndsWith("2")
                            //select m;
                foreach (var item in query){
                    Console.WriteLine("Movies: " + item.Movie.Title + " - Actor: " + item.Actor.Name);
                }
                //Editing movie title name of the 1st movie in the DB
                Movie foundMovie = db.Movies.Find(1);
                Console.WriteLine("Found movie with title: " + foundMovie.Title);
                foundMovie.Title = "White cats, Black cats...";
                db.SaveChanges();
                Console.WriteLine("Title changed to: " + foundMovie.Title);*/   
            }
        }
    }
}