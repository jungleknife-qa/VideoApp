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
    public class RentalController : ControllerBase
    {
        private MyDBContext myDbContext;

        public RentalController(MyDBContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<Rental> Get()
        {
            return (this.myDbContext.Rentals.ToList());
        }
    }
}
