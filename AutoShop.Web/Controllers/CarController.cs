using AutoMapper;
using AutoShop.Domain;
using AutoShop.Domain.Entities;
using AutoShop.Web.Models;
using Bogus;
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
        //використовуємо авто мепер
        private readonly IMapper _mapper;

        public CarController(AppEFContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            //GenerateAuto();
        }

        private void GenerateAuto()
        {
            var endDate = DateTime.Now;
            var startDate = new DateTime(endDate.Year - 10,
                endDate.Month, endDate.Day);
            //використовуємо богус для генерації
            var faker = new Faker<Car>("uk")
                .RuleFor(x=>x.Mark, f=>f.Vehicle.Manufacturer())
                .RuleFor(x=>x.Model, f=>f.Vehicle.Model())
                .RuleFor(x=>x.Year, f=>f.Date.Between(startDate, endDate).Year);
            int n = 1000;
            for (int i = 0; i < n; i++)
            {
                var car = faker.Generate();
                _context.Cars.Add(car);
                _context.SaveChanges();
            }
            
        }

        public IActionResult Index(SearchCarIndexModel search, int page = 1)
        {
            int showItems = 10;
            var query = _context.Cars.AsQueryable();
            if(!string.IsNullOrEmpty(search.Mark))
            {
                query = query.Where(x => x.Mark.ToLower().Contains(search.Mark.ToLower()));
            }
            //кількість записів, що є в БД
            int countItems = query.Count();
            //12 штук, на 1 сторінці 3 записа, скільки буде сторінок
            //13/3 = 4,0 - 5 сторінок
            var pageCount = (int)Math.Ceiling(countItems/(double)showItems);

            if (pageCount == 0) pageCount = 1;

            if(page>pageCount)
            {
                return RedirectToAction(nameof(this.Index), new { page = pageCount });
            }

            int skipItems = (page - 1) * showItems;

            query = query.Skip(skipItems).Take(showItems);


            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Cars = query
                .Select(x => _mapper.Map<CarViewModel>(x))
                .ToList();
            model.Page = page;
            model.PageCount = pageCount;
            model.Search = search;

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
