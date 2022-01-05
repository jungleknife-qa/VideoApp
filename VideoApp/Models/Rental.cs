using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoApp.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime StartRental { get; set; }
        public DateTime EndRental { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
    }
}
