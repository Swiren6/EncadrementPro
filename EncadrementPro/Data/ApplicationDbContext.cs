using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EncadrementPro.Models;


namespace EncadrementPro.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> AspNetUserRoles { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<CreneauDisponibilite> CreneauxDisponibilites { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Projet> Projets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Always call the base first
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Professeur>().HasData(
                new Professeur { Id = 1, Nom = "Dr. Sirine", Email = "Sirine@gmail.com", EstDisponible = true },
                new Professeur { Id = 2, Nom = "Dr. Aymen", Email = "Aymen@gmail.com", EstDisponible = false }
            );

            // Configure relationship with ApplicationUser
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
                
            // Other relationships
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Professeur)
                .WithMany()
                .HasForeignKey(r => r.ProfesseurId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Creneau)
                .WithMany()
                .HasForeignKey(r => r.CreneauId);
        }
    }
}