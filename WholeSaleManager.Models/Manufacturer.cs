using System.ComponentModel.DataAnnotations;

namespace WholeSaleManager.Models
{
	public class Manufacturer
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Manufacturer")]
		[Required]
		[MaxLength(55)]
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
