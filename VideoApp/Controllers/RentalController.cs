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
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Rental/GetRentals")]
        public IEnumerable<Rental> GetRentals()
        {
            return _rentalService.GetRentals();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Rental/AddRental")]
        public IActionResult AddRental(Rental rental)
        {
            _rentalService.AddRental(rental);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Rental/UpdateRental")]
        public IActionResult UpdateRental(Rental rental)
        {
            _rentalService.UpdateRental(rental);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("api/Rental/DeleteRental")]
        public IActionResult DeleteRental(int id)
        {
            var existingRental = _rentalService.GetRental(id);
            if (existingRental != null)
            {
                _rentalService.DeleteRental(existingRental.Id);
                return Ok();
            }
            return NotFound($"Rental Not Found with ID : {existingRental.Id}");
        }

        [HttpGet]
        [Route("GetRental")]
        public Rental GetRental(int id)
        {
            return _rentalService.GetRental(id);
        }
    }
}
