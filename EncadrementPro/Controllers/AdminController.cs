using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EncadrementPro.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EncadrementPro.Controllers;


public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    
    public AdminController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    //  Page d’accueil admin : liste des utilisateurs
    public IActionResult Index()
    {
        var users = _userManager.Users.ToList();
        return View(users);
    }

    //  Supprimer un utilisateur
    [HttpPost]
    public async Task<IActionResult> SupprimerUtilisateur(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            await _userManager.DeleteAsync(user);
        }
        return RedirectToAction(nameof(Index));
    }

    //  Détails d’un utilisateur (par exemple voir rôle, ID, email)
    public async Task<IActionResult> DetailsUtilisateur(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        var roles = await _userManager.GetRolesAsync(user);
        ViewBag.Roles = roles;

        return View(user);
    }

    //  Liste des projets des étudiants
    public async Task<IActionResult> Projets()
    {
        var projets = await _context.Projets
            .Include(p => p.Etudiant)
            .ToListAsync();
        return View(projets);
    }

}
