using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoApp.Models;

namespace VideoApp.Services
{
    public interface IRentalService
    {
        Rental AddRental(Rental rental);

        List<Rental> GetRental();

        void UpdateRental(Rental rental);

        void DeleteRental(int Id);

        Rental GetRental(int Id);
    }
}
