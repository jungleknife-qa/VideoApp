using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoApp.Models;
using VideoApp.DBContexts;

namespace VideoApp.Services
{
    public class MovieService : IMovieService
    {
        public MyDBContext _myDbContext;
        public MovieService(MyDBContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public Movie AddMovie(Movie movie)
        {
            _myDbContext.Movies.Add(movie);
            _myDbContext.SaveChanges();
            return movie;
        }
        public List<Movie> GetMovies()
        {
            return _myDbContext.Movies.ToList();
        }
        public void UpdateMovie(Movie movie)
        {
            _myDbContext.Movies.Update(movie);
            _myDbContext.SaveChanges();
        }
        public void DeleteMovie(int Id)
        {
            var movie = _myDbContext.Movies.FirstOrDefault(x => x.Id == Id);
            if (movie != null)
            {
                _myDbContext.Remove(movie);
                _myDbContext.SaveChanges();
            }
        }
        public Movie GetMovie(int Id)
        {
            return _myDbContext.Movies.FirstOrDefault(x => x.Id == Id);
        }
    }
}
