using Microsoft.AspNetCore.Identity;

namespace EncadrementPro.Models
{
    public class Projet
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }

        // Relation avec l'utilisateur étudiant (ou IdentityUser)
        public string EtudiantId { get; set; }
        public IdentityUser Etudiant { get; set; }

        // Ajout de la relation avec Professeur (si nécessaire)
        public string ProfesseurId { get; set; }
        public IdentityUser Professeur { get; set; }
    }
}
