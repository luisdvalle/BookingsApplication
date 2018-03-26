using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingService.Abstractions;
using BookingService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingsProcessingSolution.Controllers
{
    public class HomeController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }
    }
}