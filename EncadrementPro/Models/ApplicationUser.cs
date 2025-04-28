using EncadrementPro.Models;
using Microsoft.AspNetCore.Identity;

namespace EncadrementPro.Models
{
	public class ApplicationUser : IdentityUser
	{
		// Properties
		public virtual ICollection<Reservation> Reservations { get; set; }

	
	}
}