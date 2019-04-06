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
    public class SalidadeEmpleadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalidadeEmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalidadeEmpleados
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalidadeEmpleados.ToListAsync());
        }

        // GET: SalidadeEmpleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salidadeEmpleado = await _context.SalidadeEmpleados
                .FirstOrDefaultAsync(m => m.SalidaEmpleadoId == id);
            if (salidadeEmpleado == null)
            {
                return NotFound();
            }

            return View(salidadeEmpleado);
        }

        // GET: SalidadeEmpleados/Create
        public async Task<IActionResult> Create()
        {
            var empleados = await _context.Empleados.Where(e => e.IsActive).ToListAsync();
            ViewBag.Empleados = new SelectList(empleados,"EmpleadoId","Nombre");
         
            return View();
        }

        // POST: SalidadeEmpleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalidaEmpleadoId,TipoDeSalida,Motivo,FechaSalida,EmpleadoId")] SalidadeEmpleado salidadeEmpleado)
        {
            var query = (from a in _context.Empleados
                         where a.EmpleadoId == salidadeEmpleado.EmpleadoId
                         select a).First();

           

            if (ModelState.IsValid)
            {
                query.IsActive = false;
                _context.Add(salidadeEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salidadeEmpleado);
        }

        // GET: SalidadeEmpleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salidadeEmpleado = await _context.SalidadeEmpleados.FindAsync(id);
            if (salidadeEmpleado == null)
            {
                return NotFound();
            }
            return View(salidadeEmpleado);
        }

        // POST: SalidadeEmpleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalidaEmpleadoId,TipoDeSalida,Motivo,FechaSalida,EmpleadoId")] SalidadeEmpleado salidadeEmpleado)
        {
            if (id != salidadeEmpleado.SalidaEmpleadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salidadeEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalidadeEmpleadoExists(salidadeEmpleado.SalidaEmpleadoId))
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
            return View(salidadeEmpleado);
        }

        // GET: SalidadeEmpleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salidadeEmpleado = await _context.SalidadeEmpleados
                .FirstOrDefaultAsync(m => m.SalidaEmpleadoId == id);
            if (salidadeEmpleado == null)
            {
                return NotFound();
            }

            return View(salidadeEmpleado);
        }

        // POST: SalidadeEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salidadeEmpleado = await _context.SalidadeEmpleados.FindAsync(id);
            _context.SalidadeEmpleados.Remove(salidadeEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalidadeEmpleadoExists(int id)
        {
            return _context.SalidadeEmpleados.Any(e => e.SalidaEmpleadoId == id);
        }
    }
}
