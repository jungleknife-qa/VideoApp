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
    public class CustomerController : ControllerBase
    {
        private MyDBContext myDbContext;

        public CustomerController(MyDBContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<Customer> Get()
        {
            return (this.myDbContext.Customers.ToList());
        }
    }
}
