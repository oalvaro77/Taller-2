using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionAcademica.Data;
using GestionAcademica.Models;

namespace GestionAcademica.Controllers
{
    public class ProfesorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfesorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Profesors
        public async Task<IActionResult> Index()
        {
            var profesores = _context.Profesores.Include(p => p.Facultad);
            return View(await profesores.ToListAsync());
        }

        // GET: Profesors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            // Opcionalmente, puedes cargar las facultades aquí para mostrarlas en un dropdown.
            ViewBag.Facultades = new SelectList(_context.Facultades.ToList(), "Id", "Nombre");
            return View();
        }

        // POST: Profesores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profesor profesor)
        {
            if (!ModelState.IsValid)
            {
                _context.Profesores.Add(profesor);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Profesor creado exitosamente."; // Mensaje de éxito
                return RedirectToAction(nameof(Index)); // Redirige a la lista de profesores o a donde necesites
            }

            // Vuelve a cargar las facultades en caso de error
            ViewBag.Facultades = new SelectList(_context.Facultades.ToList(), "Id", "Nombre", profesor.FacultadId);
            return View(profesor); // Si hay un error, vuelve a mostrar el formulario
        }
        // GET: Profesors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        // POST: Profesors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Correo,FacultadId")] Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(profesor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }

        // GET: Profesors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // POST: Profesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesores.Remove(profesor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
            return _context.Profesores.Any(e => e.Id == id);
        }
    }
}
