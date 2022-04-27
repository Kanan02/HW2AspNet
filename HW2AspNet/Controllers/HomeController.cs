using HW2AspNet.Data;
using HW2AspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HW2AspNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarContext _context;
        public HomeController(ILogger<HomeController> logger,CarContext carContext)
        {
            _logger = logger;
            _context = carContext;
        }

        public IActionResult Index()
        {
            return View(_context.Cars.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCar(int id)
        {
            Car car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            _context.Remove(car);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> AddCar()
        {

            return View(null);

        }
        [HttpPost]
        public async Task<IActionResult> AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
