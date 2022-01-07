using VideoApp.DBContexts;
using VideoApp.Models;
using VideoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Movie/GetMovie")]
        public IEnumerable<Movie> GetMovies()
        {
            return _movieService.GetMovies();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Movie/AddMovie")]
        public IActionResult AddMovie(Movie movie)
        {
            _movieService.AddMovie(movie);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Movie/UpdateMovie")]
        public IActionResult UpdateMovie(Movie movie)
        {
            _movieService.UpdateMovie(movie);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("api/Movie/DeleteMovie")]
        public IActionResult DeleteMovie(int id)
        {
            var existingMovie = _movieService.GetMovie(id);
            if (existingMovie != null)
            {
                _movieService.DeleteMovie(existingMovie.Id);
                return Ok();
            }
            return NotFound($"Movie Not Found with ID : {existingMovie.Id}");
        }

        [HttpGet]
        [Route("GetMovie")]
        public Movie GetMovie(int id)
        {
            return _movieService.GetMovie(id);
        }
    }
}
