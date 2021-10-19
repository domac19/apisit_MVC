using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;

namespace Vidley.Controllers
{
    public class MovieController : Controller
    {
        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        public ActionResult Details (int id)
        {
            var movies = GetMovies().SingleOrDefault(m => m.Id == id);
            return View(movies);
        }
        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie{ Id = 1, Name = "Sherlock Holmes" },
                new Movie{ Id = 2, Name = "Star Wars" }
            };
        }
    }
}