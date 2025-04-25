using EncadrementPro.Models;

namespace EncadrementPro.Models
{
	public class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser
	{
		// Properties
		public virtual ICollection<Reservation> Reservations { get; set; }

		public ApplicationUser()
		{
			Reservations = new HashSet<Reservation>();
		}
	}
}