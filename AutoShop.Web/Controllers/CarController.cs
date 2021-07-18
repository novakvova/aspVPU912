using AutoShop.Domain;
using AutoShop.Domain.Entities;
using AutoShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly AppEFContext _context;
        public CarController(AppEFContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CarViewModel> model = _context.Cars
                .Select(x => new CarViewModel
                {
                    Id=x.Id,
                    Mark=x.Mark,
                    Model=x.Model,
                    Year=x.Year
                }).ToList();
                
                
            //    new List<CarViewModel>
            //{
            //    new CarViewModel
            //    {
            //        Id = 1,
            //        Mark = "BWM",
            //        Model = "X6",
            //        Year = 2021
            //    },
            //    new CarViewModel
            //    {
            //        Id = 2,
            //        Mark = "Лада",
            //        Model = "2106",
            //        Year = 1986
            //    }
            //};
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CarCreateViewModel carCreateView)
        {
            if (!ModelState.IsValid)
                return View(carCreateView);

            Car car = new Car
            {
                Mark= carCreateView.Mark,
                Model= carCreateView.Model,
                Year= carCreateView.Year
            };
            _context.Cars.Add(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
