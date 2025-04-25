using EncadrementPro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EncadrementPro.Data; 
namespace EncadrementPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProfesseurController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfesseurController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var profs = await _context.Professeurs.Include(p => p.User).ToListAsync();
            return View(profs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Professeur professeur)
        {
            if (ModelState.IsValid)
            {
                _context.Professeurs.Add(professeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professeur);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var prof = await _context.Professeurs.FindAsync(id);
            if (prof == null) return NotFound();
            return View(prof);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Professeur professeur)
        {
            if (id != professeur.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                _context.Update(professeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(professeur);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var prof = await _context.Professeurs.FindAsync(id);
            if (prof == null) return NotFound();

            _context.Professeurs.Remove(prof);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
