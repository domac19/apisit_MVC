using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidley.Dtos;
using Vidley.Models;

namespace Vidley.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        //GET/api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _dbContext.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        //GET/api/movie/1
        public IHttpActionResult GetMovie(int id)
        {
            var movies = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movies == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movies)); 
        }

        //POST/api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            movie.Id = movieDto.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT/api/movies
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var moviesDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (moviesDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, moviesDb);

            _dbContext.SaveChanges();
        }

        //DELETE/api/movies/1
        public void DeleteMovie(int id)
        {
            var moviesDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (moviesDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Movies.Remove(moviesDb);
            _dbContext.SaveChanges();
        }
    }
}