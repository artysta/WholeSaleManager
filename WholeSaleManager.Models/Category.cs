using System.ComponentModel.DataAnnotations;

namespace WholeSaleManager.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Display(Name="Category Name")]
		[Required]
		[MaxLength(55)]
		public string Name { get; set; }
	}
}
