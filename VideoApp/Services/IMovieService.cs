using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoApp.Models;

namespace VideoApp.Services
{
    public interface IMovieService
    {
        Movie AddMovie(Movie movie);

        List<Movie> GetMovies();

        void UpdateMovie(Movie movie);

        void DeleteMovie(int Id);

        Movie GetMovie(int Id);
    }
}
