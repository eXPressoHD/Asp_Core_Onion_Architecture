using Microsoft.AspNetCore.Mvc;
using Onion.Core.Data.Interfaces;
using Onion.Core.Domain.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Web.Controllers
{
    //[Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetUser(int userId)
        {
            var user = _userRepository.GetById(userId);

            return Ok(user);
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<User> userList = _userRepository.Get().ToList();

            return View(userList);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _userRepository.Add(user);
            _userRepository.Save();

            return RedirectToAction("Index", "User");
        }

        [HttpDelete("{id:guid}")]
        public IActionResult RemoveUser(int id)
        {
            _userRepository.Remove(id);
            _userRepository.Save();

            return Ok("Removed User");
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateUser(int id)
        {
            var user = _userRepository.GetById(id);

            user.Email = "ChangedUserName";
            user.Password = "34565";

            _userRepository.Update(user);
            _userRepository.Save();

            return Ok("Updated User");
        }
    }
}

