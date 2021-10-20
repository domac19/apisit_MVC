using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;
using System.Data.Entity;

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