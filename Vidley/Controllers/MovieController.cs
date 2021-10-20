using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;
using System.Data.Entity;
using Vidley.ViewModels;

namespace Vidley.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _dbContext;
        public MovieController()
        {
            _dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        public ActionResult New()
        {
            var genres = _dbContext.Genres.ToList();
            var viewModel = new MovieViewModel
            {
                Genres = genres
            };

            return View("FormMovies", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var movies = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return HttpNotFound();

            var viewModel = new MovieViewModel
            {
                Movie = movies,
                Genres = _dbContext.Genres.ToList()
            };

            return View("FormMovies", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var movieDb = _dbContext.Movies.Single(m => m.Id == movie.Id);
                
                movieDb.Name = movie.Name;
                movieDb.GenreType = movie.GenreType;
                movieDb.DateAdded = movie.DateAdded;
                movieDb.ReleseDate = movie.ReleseDate;
                movieDb.NumberInStock = movie.NumberInStock;
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index","Movie");
        }
        public ViewResult Index()
        {
            var movies = _dbContext.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details (int id)
        {
            var movies = _dbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movies);
        }
    }
}