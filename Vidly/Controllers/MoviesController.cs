using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //return View(movie);
            //return Content("Hello worldddd!");
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name"});

            var customers = new List<Customer>()
            { new Customer{ Name = "Marko Markovic", Id = 1},
              new Customer{Name = "Janko Jankovic", Id = 2},
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers,
            };

            return View(viewModel);
        }

        [Route("movies")]
        public ActionResult Index()
        {
           
            ExcerciseListMovieModel movies = new ExcerciseListMovieModel()
            {
                Movies = _context.Movies.Include(m => m.Genre).ToList(),
            };
            
            return View(movies);
            
        }

        [Route("movies/details/{Id}")]
        public ActionResult Details(int Id)
        {
            try
            {
                Movie movieDetails = _context.Movies.Include(c => c.Genre).Single(m => m.Id == Id);
                return View(movieDetails);
            }
            catch (InvalidOperationException e)
            {
               return RedirectToAction("NonExistingMovie", "Movies");
            };
        }

        public ActionResult Edit(int Id)
        {
            Movie movie = _context.Movies.SingleOrDefault(M => M.Id == Id);

            if(movie == null)
            {
                return HttpNotFound();
            }

            MovieFormViewModel viewModel = new MovieFormViewModel(movie)
            {
                GenreTypes = _context.GenreTypes.ToList(),
            };

            return View("MoviesForm", viewModel);
        }

        public ActionResult NonExistingMovie()
        {
            return View();
        }

        [Route("movies/released/{year}/{month:range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }

        
        public ActionResult New()
        {
            MovieFormViewModel viewModel = new MovieFormViewModel
            {
                GenreTypes = _context.GenreTypes.ToList(),
            };

            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                MovieFormViewModel viewModel = new MovieFormViewModel(movie)
                {
                    GenreTypes = _context.GenreTypes.ToList(),
                };
                return View("MoviesForm", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                Movie movieFromDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieFromDb.Name = movie.Name;
                movieFromDb.AddedDate = movie.AddedDate;
                movieFromDb.ReleaseDate = movie.ReleaseDate;
                movieFromDb.GenresId = movie.GenresId;
                movieFromDb.Stocks = movie.Stocks;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}