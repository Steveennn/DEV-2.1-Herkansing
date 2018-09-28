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

                //Adding a movie + actors to DB
                Actor a1 = new Actor {Name = "Tommy Lee"};
                Actor a2 = new Actor {Name = "Xavier Berdem"};
                Movie m1 = new Movie {
                    Title = "No country for old men",
                    Actors = new System.Collections.Generic.List<MovieActor> {
                        new MovieActor{Actor = a1},
                        new MovieActor{Actor = a2}
                    }
                };

                Actor a3 = new Actor {Name = "Timon"};
                Actor a4 = new Actor {Name = "Pumba"};
                Actor a5 = new Actor {Name = "Simba"};
                Movie m2 = new Movie {
                    Title = "The Lion King",
                    Actors = new System.Collections.Generic.List<MovieActor> {
                        new MovieActor{Actor = a3},
                        new MovieActor{Actor = a4},
                        new MovieActor{Actor = a5}
                    }
                };
                
                Actor IronMan = new Actor {Name = "Robert Downey Jr"};
                Actor Thor = new Actor {Name = "Chris Hemsworth"};
                Actor CptAmerica = new Actor {Name = "Chris Evans"};
                Movie m3 = new Movie {
                    Title = "Marvel's Avengers",
                    Actors = new System.Collections.Generic.List<MovieActor> {
                        new MovieActor{Actor = IronMan},
                        new MovieActor{Actor = Thor},
                        new MovieActor{Actor = CptAmerica}
                    }
                };

                Movie m4 = new Movie {
                    Title = "Thor",
                    Actors = new System.Collections.Generic.List<MovieActor> {
                        new MovieActor{Actor = Thor}
                    }
                };
                
                Actor BlackPanther = new Actor {Name = "Chadwick Boseman"};
                Movie m5 = new Movie {
                    Title = "Black Panther",
                    Actors = new System.Collections.Generic.List<MovieActor> {
                        new MovieActor{Actor = BlackPanther},
                        new MovieActor{Actor = CptAmerica}
                    }
                };

                Movie m6 = new Movie {
                    Title = "Avengers Infinity War",
                    Actors = new System.Collections.Generic.List<MovieActor> {
                        new MovieActor{Actor = BlackPanther},
                        new MovieActor{Actor = CptAmerica},
                        new MovieActor{Actor = IronMan},
                        new MovieActor{Actor = Thor}
                    }
                };
                                
                /*db.Movies.Add(m1);
                db.Movies.Add(m2);
                db.Movies.Add(m3);
                db.Movies.Add(m4);
                db.Movies.Add(m5);
                db.Movies.Add(m6);
                db.SaveChanges();*/

                //FEEDBACK VAN LES
                /*foreach (var movie in db.Movies) {
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

                Console.WriteLine(" ");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(" ");

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
                }*/
                var query = from m in db.Movies
                            from ma in db.MovieActor
                            where ma.MovieId == m.Id
                            from a in db.Actors
                            where ma.ActorId == a.Id
                            group a by m into g
                            where g.Count() >=3 //selecteerd films met minimaal 3 actors
                            select Tuple.Create(g.Key, new {AmountActors = g.Count()});

                var query2 = from m in db.Movies
                            let average_age =
                                (from ma in db.MovieActor
                                where ma.MovieId == m.Id
                                from a in db.Actors
                                where ma.ActorId == a.Id
                                select a).Average(a => a.Age)
                            where average_age >= 50;

                foreach (var item in query){
                    Console.WriteLine("Movie: " + item.Item1.Title + " - Actor: " + item.Item2.AmountActors);
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