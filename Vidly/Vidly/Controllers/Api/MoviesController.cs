using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.App_Start;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private VidlyDbContext _context;
        private static MapperConfiguration config;
        private IMapper mapper;

        public MoviesController()
        {
            config = new AutoMapperConfiguration().Configure();
            _context = new VidlyDbContext();
            mapper = config.CreateMapper();
        }

        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));
            }

            var movieDtos = moviesQuery
                .ToList()
                .Select(mapper.Map<Movie, MovieDto>);
            //var movieDtos = mapper.Map<IEnumerable<MovieDto>>
            //    (_context.Movies.Include(m => m.Genre).ToList());
            return Ok(movieDtos);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(mapper.Map<MovieDto>(movie));
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }
            mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
            return Ok();

        }
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
