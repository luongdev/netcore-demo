using System;
using System.Collections.Generic;
using System.Linq;
using libapp.Data.Interface;
using libapp.Data.Model;
using libapp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace libapp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;

        public CustomerController(ICustomerRepository customerRepository, IBookRepository bookingRepository)
        {
            _customerRepository = customerRepository;
            _bookRepository = bookingRepository;
        }

        public IActionResult Index() {
            var customers = _customerRepository.GetAll();
            if (!customers.Any())
                return View("Empty");

            var customerViewModels = customers.Select(customer =>
                new CustomerViewModel {
                    Customer = customer,
                    BookCount = _bookRepository.Count(book => book.BorrowerId == customer.CustomerId)
            }).ToList();
            return View("Index", customerViewModels);
        }

        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);
            _customerRepository.Delete(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create (Customer customer)
        {
            _customerRepository.Create(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var customer = _customerRepository.GetById(id);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            _customerRepository.Update(customer);
            return RedirectToAction("Index");
        }
    }
}
