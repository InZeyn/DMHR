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
    public class NominasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NominasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nominas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nominas.ToListAsync());
        }
        
        // POST: Nominas
        [HttpPost]
        public async Task<IActionResult> Index(DateTime fechaIngreso,bool getMonth,bool getYear)
        {
            if (getMonth || getMonth && getYear)
            {
                var nominas = await _context.Nominas
                .Where(e => e.Date.Month == fechaIngreso.Month).ToListAsync();
                ViewBag.Nominas = nominas;
                return View(await _context.Nominas
                .Where(e => e.Date.Month == fechaIngreso.Date.Month).ToListAsync());
               
            }

            if (getYear && !getMonth)
            {
                var nominasYear = await _context.Nominas
                .Where(e => e.Date.Year == fechaIngreso.Date.Year).ToListAsync();
                ViewBag.NominasYear = nominasYear;
                return View(await _context.Nominas
                .Where(e => e.Date.Year == fechaIngreso.Date.Year).ToListAsync());
               
            }

            return View(await _context.Nominas.ToListAsync());
        }

        // GET: Nominas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nominas
                .FirstOrDefaultAsync(m => m.NominaId == id);
            if (nomina == null)
            {
                return NotFound();
            }

            return View(nomina);
        }

        // GET: Nominas/Create
        public async Task<IActionResult> Create()
        {
            var total = await _context.Empleados.Where(e => e.IsActive == true)
                .Include(e => e.Salario)
                .SumAsync(e => e.Salario);

            ViewBag.MontoTotal = total;
            return View();
        }

        // POST: Nominas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NominaId,Date,MontoTotal")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nomina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nomina);
        }

        // GET: Nominas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nominas.FindAsync(id);
            if (nomina == null)
            {
                return NotFound();
            }
            return View(nomina);
        }

        // POST: Nominas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NominaId,Date,MontoTotal")] Nomina nomina)
        {
            if (id != nomina.NominaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nomina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NominaExists(nomina.NominaId))
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
            return View(nomina);
        }

        // GET: Nominas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nominas
                .FirstOrDefaultAsync(m => m.NominaId == id);
            if (nomina == null)
            {
                return NotFound();
            }

            return View(nomina);
        }

        // POST: Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nomina = await _context.Nominas.FindAsync(id);
            _context.Nominas.Remove(nomina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NominaExists(int id)
        {
            return _context.Nominas.Any(e => e.NominaId == id);
        }
    }
}
