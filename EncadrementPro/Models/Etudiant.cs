using EncadrementPro.Models;

public class Etudiant
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }
    public Projet? Projet { get; set; }

    // Remove this if reservations are already tracked via ApplicationUser
    // public ICollection<Reservation> Reservations { get; set; }
}