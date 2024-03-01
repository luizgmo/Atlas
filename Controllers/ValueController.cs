using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtlasP.Data;
using AtlasP.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AtlasP.Controllers
{
    public class ValueController : Controller
    {
        private readonly Contexto _context;

        public ValueController(Contexto context)
        {
            _context = context;
        }

        // GET: Value
         public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _context.Values.ToListAsync();
            return Json(new { data = values } );
        }

        // GET: Value/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @value = await _context.Modalities.FirstOrDefaultAsync(m => m.Id == id);
            if (@value == null)
            {
                return NotFound();
            }

            return View(@value);
        }

        // GET: Value/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Value/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Value value)
        {
            if (ModelState.IsValid)
            {
                _context.Add(value);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(value);
        }

        // GET: Value/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var value = await _context.Values.FindAsync(id);
            if (value == null)
            {
                return NotFound();
            }
            return View(value);
        }

        // POST: Value/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Value value)
        {
            if (id != value.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(value);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValueExists(value.Id))
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
            return View(value);
        }

        // DELETE: Value/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _context.Values.FindAsync(id);
            if (value == null)
                return Json(new { success = false, message = "Valor não localizada!!!" });
            
            try {
                _context.Values.Remove(value);
                await _context.SaveChangesAsync();
            }
            catch {
                return Json(new { success = false, message = "Ocorreu um problema inesperado! Avise ao Suporte!" });
            }
            return Json(new { success = true, message = "Valor Excluída com Sucesso!" });
        }

        private bool ValueExists(int id)
        {
            return _context.Values.Any(e => e.Id == id);
        }
    }
}
