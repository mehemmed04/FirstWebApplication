using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            var vm = new PersonAddViewModel
            {
                Person = new Person()
            };
            return View(vm);
        }


        [HttpPost]
        public IActionResult Add(PersonAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                return Redirect("/home/index");
            }
            return View(viewModel);
        }
    }
}
