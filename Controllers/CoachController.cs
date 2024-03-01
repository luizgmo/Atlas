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
    public class CoachController : Controller
    {
        private readonly Contexto _context;

        private readonly IWebHostEnvironment _hostEnvironment;

        public CoachController(Contexto context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Coach
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coachs = await _context.Coachs.ToListAsync();
            return Json(new { data = coachs } );
        }

        // GET: Coach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @coach = await _context.Coachs.FirstOrDefaultAsync(m => m.Id == id);
            if (@coach == null)
            {
                return NotFound();
            }

            return View(@coach);
        }

        // GET: Coach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Image")] Coach @coach, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString();
                    string uploads = Path.Combine(wwwRootPath, @"images\coachs");
                    string extension = Path.GetExtension(file.FileName);
                    string newFile = Path.Combine(uploads, fileName + extension);
                    using (var stream = new FileStream(newFile, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    @coach.Image = @"\images\coachs\" + fileName + extension;
                }
                _context.Add(@coach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coach);
        }

        // GET: Coach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coachs.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }
            return View(coach);
        }

        // POST: Coach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Image")] Coach @coach, IFormFile file)
        {
            if (id != coach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString();
                    string uploads = Path.Combine(wwwRootPath, @"images\coachs");
                    string extension = Path.GetExtension(file.FileName);
                    
                    if (@coach.Image != null)
                    {
                        string oldFile = Path.Combine(wwwRootPath, @coach.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }
                    }
                    
                    string newFile = Path.Combine(uploads, fileName + extension);
                    using (var stream = new FileStream(newFile, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    @coach.Image = @"\images\coachs\" + fileName + extension;
                }
                try
                {
                    _context.Update(coach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachExists(coach.Id))
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
            return View(coach);
        }

        // GET: Coach/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var @coach = _context.Coachs.Find(id);
            if (@coach == null)
            {
                return Json(new { success = false, message = "Treinador não encontrado"});
            }
            try
            {
                _context.Coachs.Remove(@coach);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return Json(new { success = false, message = "Ocorreu um problema inesperado! Avise ao Suporte!"});
            }
            return Json(new { success = true, message = "Treinador Excluído com Sucesso"});
        }

        private bool CoachExists(int id)
        {
            return _context.Coachs.Any(e => e.Id == id);
        }
    }
}
