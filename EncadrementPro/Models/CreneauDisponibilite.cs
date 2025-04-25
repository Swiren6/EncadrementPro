using System;
using EncadrementPro.Models;

namespace EncadrementPro.Models
{
    public class CreneauDisponibilite
    {
        public int Id { get; set; }
        public DateTime Horaire { get; set; }

        public int ProfesseurId { get; set; }
        public Professeur Professeur { get; set; }
    }
}
