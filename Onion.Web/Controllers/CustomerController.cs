using Microsoft.AspNetCore.Mvc;
using Onion.Core.Domain.Dto.Customer;
using Onion.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Onion.Infrastructure.Data.ViewModels;

namespace Onion.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Overview()
        {
            List<Customer> userDtos = _customerRepository.Get().ToList(); //List DTOS
            List<CustomerViewModel> customerListViewModel = _mapper.Map<List<CustomerViewModel>>(userDtos);

            CustomerListViewModel vm = new CustomerListViewModel()
            {
                AllCustomers = customerListViewModel
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
            CustomerViewModel customerView = _mapper.Map<CustomerViewModel>(customer);

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
            CustomerViewModel vm = _mapper.Map<CustomerViewModel>(customer);

            return View(vm);
        }

        public IActionResult UpdateCustomer(Customer customer)
        {
            CustomerViewModel vm = _mapper.Map<CustomerViewModel>(customer);
            _customerRepository.Update(customer);
            _customerRepository.Save();

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
