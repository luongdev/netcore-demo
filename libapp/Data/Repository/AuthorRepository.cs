using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using libapp.Data.Interface;
using libapp.Data.Model;

namespace libapp.Data.Repository
{
  public class AuthorRepository : Repository<Author> ,IAuthorRepository
  {
    public AuthorRepository(LibDbContext context) : base(context)
    {
    }
    public IEnumerable<Author> GetAllWithBooks() => _context.Authors.Include(author => author.Books);
    public Author getWithBooks(int id) => _context.Authors
                                            .Where(author => author.AuthorId == id)
                                            .Include(author => author.Books)
                                            .FirstOrDefault();
  }
}