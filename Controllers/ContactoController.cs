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

        public IActionResult Listar()
        {
            var listContactos=_context.Contactos.OrderBy(y => y.nombre).OrderBy(x => x.descripcion).ToList();
            return View(listContactos);
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,nombre,autor,idioma,isbn,editorial,precio,pagina,descripcion,imagen")] Contacto contacto)
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
                  TempData["prueba02"] = "prueba02";
                return RedirectToAction(nameof(Listar));
            }
            return View(contacto);
        }
        

        // GET: http://localhost:5000/Contacto/Delete/6 MUESTRA Contacto
        public IActionResult Delete(int? id)
        {
            var contacto = _context.Contactos.Find(id);
            _context.Contactos.Remove(contacto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Enviar(Contacto objFormulario)
        {
              if (ModelState.IsValid)
                {
              _context.Add(objFormulario);
                _context.SaveChanges();
                TempData["prueba"] = "prueba01";
                objFormulario.Respuesta = "Gracias. Formulario enviado";
                return RedirectToAction("Listar");  
                }
                return View("index", objFormulario);
        }
    }
}