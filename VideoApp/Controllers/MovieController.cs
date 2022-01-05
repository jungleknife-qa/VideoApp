using VideoApp.DBContexts;
using VideoApp.Models;
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
        private MyDBContext myDbContext;

        public MovieController(MyDBContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<Movie> Get()
        {
            return (this.myDbContext.Movies.ToList());
        }
    }
}
