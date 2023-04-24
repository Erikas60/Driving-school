using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Driving_school.Models
{
	public class RegisterModel
	{
		[Required]
		[StringLength(20, MinimumLength = 3)]
		[DisplayName("First name")]
		public string Name { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 3)]
		[DisplayName("Second name")]
		public string Surname { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayName("Birth date")]
		public DateTime BirthDate { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 5)]
		[DisplayName("Username")]
		public string UserName { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 5)]
		[DisplayName("Password (Use numbers for creating password)")]
		public string Password { get; set; }

	}
}