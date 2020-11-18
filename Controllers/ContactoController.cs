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
    public class ContactoController : Controller
    {

       private readonly ILogger<ContactoController> _logger;
       private readonly ApplicationDbContext _context;


        public ContactoController(ILogger<ContactoController> logger,
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
        public IActionResult Create(Contacto objContacto){
            if (ModelState.IsValid)
            {
                _context.Add(objContacto);
                _context.SaveChanges();
                objContacto.Respuesta = "Gracias estamos en contacto";
            }
            return View(objContacto);
        }

        // GET: Contacto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,LastName,Email,Phone")] Contacto contacto)
        {
            if (id != contacto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contacto);
        }
        

        // GET: http://localhost:5000/Contacto/Delete/6 MUESTRA Contacto
        public IActionResult Delete(int? id)
        {
            var contacto = _context.Contactos.Find(id);
            _context.Contactos.Remove(contacto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Enviar(Contacto objFormulario)
        {
                objFormulario.Respuesta = "YA ESTAS REGISTRADO EL LIBRO " + "\n" + objFormulario.nombre;
                _context.Add(objFormulario);
                _context.SaveChanges();
                return View("index", objFormulario);
        }
    }
}