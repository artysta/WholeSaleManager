using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WholeSaleManager.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		[Required]
		[Range(1, 10000)]
		public double ListPrice { get; set; }

		// Price which customer will pay, if he orders less than 50 products.
		[Required]
		[Range(1, 10000)]
		public double Price { get; set; }

		// Price which customer will pay, if he orders 50 - 99 products.
		[Required]
		[Range(1, 10000)]
		public double Price50 { get; set; }

		// Price which customer will pay, if he orders more than 100 products.
		[Required]
		[Range(1, 10000)]
		public double Price100 { get; set; }

		public string ImageUrl { get; set; }

		[Required]
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public Category Category { get; set; }

		[Required]
		public int ManufacturerId { get; set; }

		[ForeignKey("ManufacturerId")]
		public Manufacturer Manufacturer { get; set; }
	}
}
