using System;
using System.Collections.Generic;
using System.Linq;
using libapp.Data.Interface;
using libapp.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace libapp.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository __bookRepository;
        private IAuthorRepository __authorRepository;

        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            __bookRepository = bookRepository;
            __authorRepository = authorRepository;
        }

        public IActionResult Index(int? authorId, int? borrowId) 
        {
            if (authorId == null && borrowId == null)
            {
                var books = __bookRepository.GetAllWithAuthor();
                return CheckBooks(books);
            } 

            if (authorId != null)
            {
                var author = __authorRepository.getWithBooks((int)authorId);
                if (!author.Books.Any())
                    return View("AuthorEmpty", author);
                return View(author.Books);
            } 

            if (borrowId != null)
            {
                var books = __bookRepository.FindWithAuthorAndBorrower(book => book.BorrowerId == borrowId);
                return CheckBooks(books);
            } 
                throw new ArgumentException();
           
        }


        public IActionResult CheckBooks(IEnumerable<Book> books)
        {
            return !books.Any() ? View("Empty") : View(books);
        }
    }
}
