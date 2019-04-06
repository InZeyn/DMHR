using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DMHR.Data;
using DMHR.Models;
using System.Threading;

namespace DMHR.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ApplicationDbContext _context;
     

        public EmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empleados?isActive
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
           
            var _indexContext = _context.Empleados.Where(e => e.IsActive);

            if (!String.IsNullOrEmpty(searchString))
            {
                _indexContext = _indexContext.Where(s => s.Nombre.ToUpper().Contains(searchString.ToUpper())
                                       || s.DepartamentoNombre.ToUpper().Contains(searchString.ToUpper()));
            }
            return View(await _indexContext.AsNoTracking().ToListAsync());
        }
        
        // GET: Empleados!isActive?
        public async Task<IActionResult> Index2()
        {
            var _indexContext = _context.Empleados.Where(e => !e.IsActive).ToListAsync();
            return View(await _indexContext);
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(m => m.EmpleadoId == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Entry/
       
        public async Task<IActionResult> Entrys()
        {

            return  View(await _context.Empleados.Where(e => e.FechaIngreso == DateTime.Today).ToListAsync());
        }

        // GET: Empleados/Entry/04/04/2019
        [HttpPost]
        public async Task<IActionResult> Entrys(DateTime fechaIngreso)
        {
            if (fechaIngreso == null)
            {
                return NotFound();
            }

            var empleados = _context.Empleados
                .Where(e => e.FechaIngreso.Month == fechaIngreso.Month && e.FechaIngreso.Year == fechaIngreso.Year);

            return empleados == null ? NotFound() : (IActionResult)View(await empleados.ToListAsync());
        }
        
        // GET: Empleados/Exit/
       
        public async Task<IActionResult> Exit()
        {

            return  View(await _context.Empleados.Where(e => e.FechaIngreso == DateTime.Today && !e.IsActive).ToListAsync());
        }

        // GET: Empleados/Entry/04/04/2019
        [HttpPost]
        public async Task<IActionResult> Exit(DateTime fechaIngreso)
        {
            if (fechaIngreso == null)
            {
                return NotFound();
            }

            var empleados = _context.Empleados
                .Where(e => e.FechaIngreso.Month == fechaIngreso.Month && e.FechaIngreso.Year == fechaIngreso.Year && !e.IsActive);

            return empleados == null ? NotFound() : (IActionResult)View(await empleados.ToListAsync());
        }

        // GET: Empleados/Create
        public async Task<IActionResult> Create()
        {
            var cargos = await _context.Cargos.ToListAsync();
            var departamentos = await _context.Departamentos.ToListAsync();
            
            var ListaCargos = new SelectList(cargos,"CargoNombre","CargoNombre");
            ViewBag.Cargos = ListaCargos;
            var ListaDepartamentos = new SelectList(departamentos,"DepartamentoNombre","DepartamentoNombre");
            ViewBag.Departamentos = ListaDepartamentos;

            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadoId,CodigoEmpleado,Nombre,Apellido,Telefono,FechaIngreso,Salario,IsActive,CargoNombre,DepartamentoNombre")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleadoId,CodigoEmpleado,Nombre,Apellido,Telefono,FechaIngreso,Salario,IsActive,CargoNombre,DepartamentoNombre")] Empleado empleado)
        {
            if (id != empleado.EmpleadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.EmpleadoId))
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
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(m => m.EmpleadoId == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.EmpleadoId == id);
        }
    }
}
