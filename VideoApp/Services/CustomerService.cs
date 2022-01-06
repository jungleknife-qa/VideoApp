using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoApp.Models;
using VideoApp.DBContexts;

namespace VideoApp.Services
{
    public class CustomerService : ICustomerService
    {
        public MyDBContext _customerDbContext;
        public CustomerService(MyDBContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        public Customer AddCustomer(Customer customer)
        {
            _customerDbContext.Customers.Add(customer);
            _customerDbContext.SaveChanges();
            return customer;
        }
        public List<Customer> GetCustomers()
        {
            return _customerDbContext.Customers.ToList();
        }
        public void UpdateCustomer(Customer customer)
        {
            _customerDbContext.Customers.Update(customer);
            _customerDbContext.SaveChanges();
        }
        public void DeleteCustomer(int Id)
        {
            var customer = _customerDbContext.Customers.FirstOrDefault(x => x.Id == Id);
            if (customer != null)
            {
                _customerDbContext.Remove(customer);
                _customerDbContext.SaveChanges();
            }
        }
        public Customer GetCustomer(int Id)
        {
            return _customerDbContext.Customers.FirstOrDefault(x => x.Id == Id);
        }
    }
}
