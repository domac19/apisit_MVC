using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.Controllers.API
{
    public class RentalsController : ApiController
    {
        public ApplicationDbContext _dbContext { get; set; }
        public RentalsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // POST/api/rentals
        [HttpPost]
        public IHttpActionResult PostRental(RentalDto rentalDto)
        {
            var customers = _dbContext.Customers.Single(c => c.Id == rentalDto.CustomerId);

            var movies = _dbContext.Movies.Where(m => rentalDto.MovieId.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.IsAvaliable == 0)
                    return BadRequest("Movie is not avaliable!");
                
                movie.IsAvaliable--;

                var rent = new Rental
                {
                    Customer = customers,
                    Movie = movie,
                    RentDate = DateTime.Now,
                    RentReturn = DateTime.Now
                };
                _dbContext.Rentals.Add(rent);
            }
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
