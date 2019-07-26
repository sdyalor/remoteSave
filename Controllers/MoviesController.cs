using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapi4.Models;

namespace webapi4.Controllers
{
    public class MoviesController : Controller
    {
        private readonly NeumaticosContext _context;

        public MoviesController(NeumaticosContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var neumaticosContext = _context.SnVehiculo.Include(s => s.Cod).Include(s => s.Cod1).Include(s => s.Cod2).Include(s => s.CodC).Include(s => s.CodCiaNavigation).Include(s => s.CodNavigation);
            return View(await neumaticosContext.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snVehiculo = await _context.SnVehiculo
                .Include(s => s.Cod)
                .Include(s => s.Cod1)
                .Include(s => s.Cod2)
                .Include(s => s.CodC)
                .Include(s => s.CodCiaNavigation)
                .Include(s => s.CodNavigation)
                .FirstOrDefaultAsync(m => m.CodCia == id);
            if (snVehiculo == null)
            {
                return NotFound();
            }

            return View(snVehiculo);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["CodCia"] = new SelectList(_context.SnMarcaVehiculo, "CodCia", "CodCia");
            ViewData["CodCia"] = new SelectList(_context.SnTipoVehiculo, "CodCia", "CodCia");
            ViewData["CodCia"] = new SelectList(_context.SnModeloVehiculo, "CodCia", "CodCia");
            ViewData["CodCia"] = new SelectList(_context.SnConfiguracion, "CodCia", "CodCia");
            ViewData["CodCia"] = new SelectList(_context.SnCiaNeumatico, "CodCia", "CodCia");
            ViewData["CodCia"] = new SelectList(_context.SnObraNeumatico, "CodCia", "CodCia");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodCia,CodObra,CodVehiculo,Placa,Prefijo,CodMarca,CodModelo,CodTipo,CodConfiguracion,Descripcion,Estado,Variable,IndVehiAlma,NroSerie,Notas,Fecha,Usuario,Clase,Situacion,Linea,Propiedad,Idcarga,Linecarga")] SnVehiculo snVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodCia"] = new SelectList(_context.SnMarcaVehiculo, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnTipoVehiculo, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnModeloVehiculo, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnConfiguracion, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnCiaNeumatico, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnObraNeumatico, "CodCia", "CodCia", snVehiculo.CodCia);
            return View(snVehiculo);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snVehiculo = await _context.SnVehiculo.FindAsync(id);
            if (snVehiculo == null)
            {
                return NotFound();
            }
            ViewData["CodCia"] = new SelectList(_context.SnMarcaVehiculo, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnTipoVehiculo, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnModeloVehiculo, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnConfiguracion, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnCiaNeumatico, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnObraNeumatico, "CodCia", "CodCia", snVehiculo.CodCia);
            return View(snVehiculo);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodCia,CodObra,CodVehiculo,Placa,Prefijo,CodMarca,CodModelo,CodTipo,CodConfiguracion,Descripcion,Estado,Variable,IndVehiAlma,NroSerie,Notas,Fecha,Usuario,Clase,Situacion,Linea,Propiedad,Idcarga,Linecarga")] SnVehiculo snVehiculo)
        {
            if (id != snVehiculo.CodCia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snVehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnVehiculoExists(snVehiculo.CodCia))
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
            ViewData["CodCia"] = new SelectList(_context.SnMarcaVehiculo, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnTipoVehiculo, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnModeloVehiculo, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnConfiguracion, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnCiaNeumatico, "CodCia", "CodCia", snVehiculo.CodCia);
            ViewData["CodCia"] = new SelectList(_context.SnObraNeumatico, "CodCia", "CodCia", snVehiculo.CodCia);
            return View(snVehiculo);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snVehiculo = await _context.SnVehiculo
                .Include(s => s.Cod)
                .Include(s => s.Cod1)
                .Include(s => s.Cod2)
                .Include(s => s.CodC)
                .Include(s => s.CodCiaNavigation)
                .Include(s => s.CodNavigation)
                .FirstOrDefaultAsync(m => m.CodCia == id);
            if (snVehiculo == null)
            {
                return NotFound();
            }

            return View(snVehiculo);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var snVehiculo = await _context.SnVehiculo.FindAsync(id);
            _context.SnVehiculo.Remove(snVehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnVehiculoExists(string id)
        {
            return _context.SnVehiculo.Any(e => e.CodCia == id);
        }
    }
}
