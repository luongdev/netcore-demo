using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using libapp.Data.Interface;
using libapp.Data.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace libapp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository __authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            this.__authorRepository = authorRepository;
        }

        [Route("Author")]
        public IActionResult Index()
        {
            var authors = __authorRepository.GetAllWithBooks();
            if (!authors.Any()) return View("Empty");
            return View(authors);
        }

        public IActionResult Update(int id)
        {
            var author = __authorRepository.GetById(id);
            if (author == null) return NotFound();
            return View(author);
        }

        [HttpPost]
        public IActionResult Update(Author author)
        {
            __authorRepository.Update(author);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            __authorRepository.Create(author);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var author = __authorRepository.GetById(id);
            __authorRepository.Delete(author);
            return RedirectToAction("Index");
        }
    }
}
