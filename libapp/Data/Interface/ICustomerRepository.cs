using System.Collections.Generic;
using libapp.Data.Model;

namespace libapp.Data.Interface
{
  public interface ICustomerRepository: IRepository<Customer>
  {
      IEnumerable<Customer> GetAllWithBooks();
      Customer getWithBooks(int id);
  }
}