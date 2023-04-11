﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
       
        public string Index()
        {
            return "Hello from Index action";
        }

        public IActionResult Index2()
        {
            return View();
        }

        public ViewResult Persons()
        {
            List<Person> persons = new List<Person>
            {
                new Person
                {
                    Name="Mehemmed",
                     Surname="Bayramov",
                      Image="Path1",
                       Age=18
                },
                   new Person
                {
                    Name="Ayxan",
                     Surname="Aliyev",
                      Image="Path2",
                       Age=19
                },
                      new Person
                {
                    Name="Ashraf",
                     Surname="Quluzade",
                      Image="Path3",
                       Age=20
                }
            };
            var vm = new PersonViewModel
            {
                Persons = persons
            };
            return View(vm);
        }

        public ViewResult Employees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    CityId=1,
                    Firstname="Huseyn",
                    Lastname="Abbasov"
                },
                new Employee
                {
                    Id=2,
                    CityId=1,
                     Firstname="Ilkin",
                      Lastname="Suleymanov"
                },
                new Employee
                {
                    Id=3,
                    CityId=2,
                    Firstname="Alirza",
                    Lastname="Zaidov"
                }
            };

            List<string> cities = new List<string> { "Baku", "Bern", "Stockholm" };

            var vm = new EmployeeViewModel
            {
                Employees = employees,
                Cities = cities
            };
            return View(vm);
        }


        public IActionResult Index4()
        {
            return Ok();
        }
        public IActionResult Index5()
        {
            return NotFound();
        }
        public IActionResult Index6()
        {
            return BadRequest();
        }

        public IActionResult Index7()
        {
            return Redirect("/home/index");
        }

        public IActionResult Index8()
        {
            return RedirectToAction("employees");
        }

        public IActionResult Index9()
        {
            var routeValue = new RouteValueDictionary(
                new { action = "Employees", controller = "Home" });
            return RedirectToRoute(routeValue);
        }

        public JsonResult GetJson()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    CityId=1,
                    Firstname="Huseyn",
                    Lastname="Abbasov"
                },
                new Employee
                {
                    Id=2,
                    CityId=1,
                     Firstname="Ilkin",
                      Lastname="Suleymanov"
                },
                new Employee
                {
                    Id=3,
                    CityId=2,
                    Firstname="Alirza",
                    Lastname="Zaidov"
                }
            };
            return Json(employees);
        }
        public JsonResult Index10(int id=-1)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    CityId=1,
                    Firstname="Huseyn",
                    Lastname="Abbasov"
                },
                new Employee
                {
                    Id=2,
                    CityId=1,
                     Firstname="Ilkin",
                      Lastname="Suleymanov"
                },
                new Employee
                {
                    Id=3,
                    CityId=2,
                    Firstname="Alirza",
                    Lastname="Zaidov"
                }
            };
            if(id==-1)
            return Json(employees);
            else
            {
                var data = employees.FirstOrDefault(e => e.Id == id);
                return Json(data);
            }
        }
        
        public JsonResult Index11(string key,int id = -1)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    CityId=1,
                    Firstname="Huseyn",
                    Lastname="Abbasov"
                },
                new Employee
                {
                    Id=2,
                    CityId=1,
                     Firstname="Ilkin",
                      Lastname="Suleymanov"
                },
                new Employee
                {
                    Id=3,
                    CityId=2,
                    Firstname="Alirza",
                    Lastname="Zaidov"
                }
            };
            if (id == -1)
            {
                var data = employees.Where(e => e.Firstname.Contains(key));
                return Json(data);
            }
            else
            {
                var data=employees.Where(e => e.Id == id || 
                e.Firstname.Contains(key));
                return Json(data);
            }
        }

        public string RouteData(int id)
        {
            return id.ToString();
        }
        public string Query(int id,string key)
        {
            return $"ID {id}  KEY {key}";
        }
    }
}
