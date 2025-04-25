using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EncadrementPro.Models;

namespace EncadrementPro.Data
{
    public class TestDbContext : IdentityDbContext<ApplicationUser>
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        // No DbSets or custom configurations
    }
}