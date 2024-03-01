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
    public class ModalityController : Controller
    {
        private readonly Contexto _context;

        private readonly IWebHostEnvironment _hostEnvironment;

        public ModalityController(Contexto context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Modality
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var modalities = await _context.Modalities.ToListAsync();
            return Json(new { data = modalities } );
        }

        // GET: Modality/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @modality = await _context.Modalities.FirstOrDefaultAsync(m => m.Id == id);
            if (@modality == null)
            {
                return NotFound();
            }

            return View(@modality);
        }

        // GET: Modality/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modality/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Image")] Modality @modality, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString();
                    string uploads = Path.Combine(wwwRootPath, @"images\modalities");
                    string extension = Path.GetExtension(file.FileName);
                    string newFile = Path.Combine(uploads, fileName + extension);
                    using (var stream = new FileStream(newFile, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    @modality.Image = @"\images\modalities\" + fileName + extension;
                }
                _context.Add(@modality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modality);
        }

        // GET: Modality/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modality = await _context.Modalities.FindAsync(id);
            if (modality == null)
            {
                return NotFound();
            }
            return View(modality);
        }

        // POST: Modality/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Image")] Modality @modality, IFormFile file)
        {
            if (id != modality.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString();
                    string uploads = Path.Combine(wwwRootPath, @"images\modalities");
                    string extension = Path.GetExtension(file.FileName);
                    
                    if (@modality.Image != null)
                    {
                        string oldFile = Path.Combine(wwwRootPath, @modality.Image.TrimStart('\\'));
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
                    @modality.Image = @"\images\modalities\" + fileName + extension;
                }
                try
                {
                    _context.Update(modality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModalityExists(modality.Id))
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
            return View(modality);
        }

        // GET: Modality/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var @modality = _context.Modalities.Find(id);
            if (@modality == null)
            {
                return Json(new { success = false, message = "Modalidade não encontrado"});
            }
            try
            {
                _context.Modalities.Remove(@modality);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return Json(new { success = false, message = "Ocorreu um problema inesperado! Avise ao Suporte!"});
            }
            return Json(new { success = true, message = "Modalidade Excluído com Sucesso"});
        }

        private bool ModalityExists(int id)
        {
            return _context.Modalities.Any(e => e.Id == id);
        }
    }
}