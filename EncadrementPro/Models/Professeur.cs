using System.Collections.Generic;

namespace EncadrementPro.Models
{
    public class Professeur
    {
        public int Id { get; set; }

        public string Nom { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string Specialite { get; set; }
        public bool EstDisponible { get; set; }

        public ICollection<CreneauDisponibilite> Disponibilites { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
