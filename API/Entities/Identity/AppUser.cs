using System;
using Microsoft.AspNetCore.Identity;

namespace API.Entities.Identity
{
	public class AppUser : IdentityUser
	{
		public string DisplayName { get; set; }

		/// One-To-One relationship between AppUser and Address
		public Address Address { get; set; }
	}
}

