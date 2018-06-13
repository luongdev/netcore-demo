using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using libapp.Data.Model;
using libapp.Data.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace libapp.Controllers.Rest
{
    [Route("api/customer")]
    public class CustomerRestController : Controller
    {
        private readonly ICustomerRepository __customerRepository;

        public CustomerRestController(ICustomerRepository customerRepository){
            __customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("findall")]
        public IEnumerable<Customer> FindAll()
        {
            return __customerRepository.GetAll();
        }
    }
}
