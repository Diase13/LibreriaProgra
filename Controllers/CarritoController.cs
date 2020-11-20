using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibreriaProgra.Models;
using LibreriaProgra.Data;

namespace LibreriaProgra.Controllers
{
    public class CarritoController : Controller
    {

       private readonly ILogger<CarritoController> _logger;
       private readonly ApplicationDbContext _context;


        public CarritoController(ILogger<CarritoController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Confimar(Carrito objCarrito)
        {
            if (ModelState.IsValid)
                {
                    _context.Add(objCarrito);
                    _context.SaveChanges();
                    objCarrito.Response = "Compra Realizada " ;
                }                
            return View("index", objCarrito);
        }
    }
}

