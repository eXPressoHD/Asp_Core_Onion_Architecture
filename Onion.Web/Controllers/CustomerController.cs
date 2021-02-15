using Microsoft.AspNetCore.Mvc;
using Onion.Core.Domain.Dto.Customer;
using Onion.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult Overview()
        {
            List<Customer> customers = _customerRepository.Get().ToList();

            CustomerViewModel vm = new CustomerViewModel()
            {
                AllCustomers = customers
            };          

            return View(vm);
        }

        #region Create Customer
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            customer.DateRegisteredTimestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            _customerRepository.Add(customer);
            _customerRepository.Save();

            return RedirectToAction("Overview", "Customer");
        }

        #endregion

        #region Edit

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var customer = _customerRepository.GetById(id);            

            return View(customer);
        }

        public IActionResult UpdateCustomer(Customer customer)
        {
            _customerRepository.Update(customer);            

            return RedirectToAction("Overview", "Customer");
        }

        #endregion

        #region Deleteoperation

        public IActionResult DeleteCustomer(int id)
        {
            if(id == 0)
            {
                return View();
            }

            _customerRepository.Remove(id);
            _customerRepository.Save();

            return RedirectToAction("Overview", "Customer");
        }

        #endregion

    }
}
