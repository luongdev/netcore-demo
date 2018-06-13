using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using libapp.Data.Interface;
using libapp.Data.Model;

namespace libapp.Data.Repository
{
  public class BookRepository : Repository<Book>, IBookRepository
  {
    public BookRepository(LibDbContext context) : base(context)
    {
    }

    public IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate) => _context.Books.Include(book => book.Author).Where(predicate);

    public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate) => _context.Books.Include(book => book.Author).Include(book => book.Borrower)
    .Where(predicate);

    public IEnumerable<Book> GetAllWithAuthor() => _context.Books.Include(book => book.Author);
  }
}