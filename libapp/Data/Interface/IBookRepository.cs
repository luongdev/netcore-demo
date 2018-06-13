using System;
using System.Collections.Generic;
using libapp.Data.Model;

namespace libapp.Data.Interface
{
  public interface IBookRepository : IRepository<Book>
  {
      IEnumerable<Book> GetAllWithAuthor();
      IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate);
      IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate);
  }
}