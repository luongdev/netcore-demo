using System.Collections.Generic;
using libapp.Data.Model;

namespace libapp.Data.Interface
{
  public interface IAuthorRepository : IRepository<Author>
  {
      IEnumerable<Author> GetAllWithBooks();
      Author getWithBooks(int id);
  }
}