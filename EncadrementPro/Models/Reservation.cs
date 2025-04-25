namespace EncadrementPro.Models;
using EncadrementPro.Models;

public class Reservation
{
    public int Id { get; set; }
    public DateTime DateReservation { get; set; }
    public bool EstConfirmee { get; set; }

    // Foreign keys
    public int ProfesseurId { get; set; }
    public int CreneauId { get; set; }
    public string UserId { get; set; } = string.Empty;

    // Navigation properties - make all nullable
    public Professeur? Professeur { get; set; }
    public CreneauDisponibilite? Creneau { get; set; }
    public ApplicationUser? User { get; set; }
}