using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using libapp.Data.Interface;
using libapp.Data.Model;

namespace libapp.Data.Repository
{
  public class CustomerRepository : Repository<Customer>, ICustomerRepository
  {
    public CustomerRepository(LibDbContext context) : base(context)
    {
    }

    public IEnumerable<Customer> GetAllWithBooks() => _context.Customers.Include(customer => customer.Books);

    public Customer getWithBooks(int id) => _context.Customers.Where(customer => customer.CustomerId == id).Include(customer => customer.Books).FirstOrDefault();
  }
}