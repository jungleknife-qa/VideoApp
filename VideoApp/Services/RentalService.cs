using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoApp.Models;
using VideoApp.DBContexts;

namespace VideoApp.Services
{
    public class RentalService : IRentalService
    {
        public MyDBContext _myDbContext;
        public RentalService(MyDBContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public Rental AddRental(Rental rental)
        {
            _myDbContext.Rentals.Add(rental);
            _myDbContext.SaveChanges();
            return rental;
        }
        public List<Rental> GetRental()
        {
            return _myDbContext.Rentals.ToList();
        }
        public void UpdateRental(Rental rental)
        {
            _myDbContext.Rentals.Update(rental);
            _myDbContext.SaveChanges();
        }
        public void DeleteRental(int Id)
        {
            var rental = _myDbContext.Rentals.FirstOrDefault(x => x.Id == Id);
            if (rental != null)
            {
                _myDbContext.Remove(rental);
                _myDbContext.SaveChanges();
            }
        }
        public Rental GetRental(int Id)
        {
            return _myDbContext.Rentals.FirstOrDefault(x => x.Id == Id);
        }
    }
}
