using EncadrementPro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EncadrementPro.Data; // Add this using directive


namespace EncadrementPro.Controllers
{
    [Authorize(Roles = "Etudiant")]
    public class EtudiantController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EtudiantController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var profs = await _context.Professeurs.Where(p => p.EstDisponible).ToListAsync();
            return View(profs);
        }

        public async Task<IActionResult> Reserver()
        {
            var profs = await _context.Professeurs.Include(p => p.Disponibilites).ToListAsync();
            return View(profs);
        }

        [HttpPost]
        public async Task<IActionResult> Reserver(int creneauId)
        {
            var user = await _userManager.GetUserAsync(User);

            var creneau = await _context.CreneauxDisponibilites
                .Include(c => c.Professeur)
                .FirstOrDefaultAsync(c => c.Id == creneauId);

            if (creneau == null) return NotFound();

            var reservation = new Reservation
            {
                CreneauId = creneauId,
                ProfesseurId = creneau.ProfesseurId,
                DateReservation = DateTime.Now,
                EstConfirmee = false,
                UserId = user.Id // Use the correct property name
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MesReservations));
        }

        public async Task<IActionResult> MesReservations()
        {
            var user = await _userManager.GetUserAsync(User);
            var reservations = await _context.Reservations
                .Include(r => r.Creneau)
                .Include(r => r.Professeur)
                .Where(r => r.UserId == user.Id) 

                .ToListAsync();

            return View(reservations);
        }
    }
}
