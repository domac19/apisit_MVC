using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
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

        [Authorize]
        public ActionResult New()
        {
            var genres = _dbContext.Genres.ToList();
            var viewModel = new MovieViewModel
            {
                Movie = new Movie(),
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
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel
                {
                    Movie = movie,
                    Genres = _dbContext.Genres.ToList()
                };
                return View("FormMovies", viewModel);
            }
            if (movie.Id == 0)
            {
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var movieDb = _dbContext.Movies.Single(m => m.Id == movie.Id);
                
                movieDb.Name = movie.Name;
                movieDb.Genre_Id = movie.Genre_Id;
                movieDb.DateAdded = movie.DateAdded;
                movieDb.ReleseDate = movie.ReleseDate;
                movieDb.NumberInStock = movie.NumberInStock;
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index","Movie");
        }
        public ViewResult Index()
        {
            if (!User.IsInRole(RoleNames.CanManageMovies))
                return View("Index");
            else
                return View("ReadOnlyList");
        }

        public ActionResult Details (int id)
        {
            var movies = _dbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movies);
        }
    }
}