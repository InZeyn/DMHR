using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DMHR.Data;
using DMHR.Models;

namespace DMHR.Controllers
{
    public class VacacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VacacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vacaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vacaciones.ToListAsync());
        }

        // GET: Vacaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacacion = await _context.Vacaciones
                .FirstOrDefaultAsync(m => m.VacacionId == id);
            if (vacacion == null)
            {
                return NotFound();
            }

            return View(vacacion);
        }

        // GET: Vacaciones/Create
        public async Task<IActionResult> Create()
        {
            var empleados = await _context.Empleados.ToListAsync();
            var ListaEmpleados = new SelectList(empleados, "EmpleadoId", "NombreCompleto");
            ViewBag.Empleados = ListaEmpleados;

            return View();
        }

        // POST: Vacaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacacionId,Desde,Hasta,Año,Comentarios,IsPaid,EmpleadoId")] Vacacion vacacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacacion);
        }

        // GET: Vacaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacacion = await _context.Vacaciones.FindAsync(id);
            if (vacacion == null)
            {
                return NotFound();
            }
            return View(vacacion);
        }

        // POST: Vacaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacacionId,Desde,Hasta,Año,Comentarios,IsPaid,EmpleadoId")] Vacacion vacacion)
        {
            if (id != vacacion.VacacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacacionExists(vacacion.VacacionId))
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
            return View(vacacion);
        }

        // GET: Vacaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacacion = await _context.Vacaciones
                .FirstOrDefaultAsync(m => m.VacacionId == id);
            if (vacacion == null)
            {
                return NotFound();
            }

            return View(vacacion);
        }

        // POST: Vacaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacacion = await _context.Vacaciones.FindAsync(id);
            _context.Vacaciones.Remove(vacacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacacionExists(int id)
        {
            return _context.Vacaciones.Any(e => e.VacacionId == id);
        }
    }
}
