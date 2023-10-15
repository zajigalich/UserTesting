using Microsoft.AspNetCore.Identity;

namespace UserTesting.DAL.Entities
{
	public class User : IdentityUser
	{
		// Navigational props
		public virtual ICollection<UserTest> UserTests { get; set; }

		// Skipping props
		public virtual ICollection<Test> Tests { get; set; }
	}
}
