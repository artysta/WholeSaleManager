using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WholeSaleManager.Models.ViewModels
{
	public class ProductViewModel
	{
		public Product Product { get; set; }
		public IEnumerable<SelectListItem> CategoryList { get; set; }
		public IEnumerable<SelectListItem> ManufacturerList { get; set; }
	}
}
