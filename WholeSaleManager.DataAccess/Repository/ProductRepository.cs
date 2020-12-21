using WholeSaleManager.DataAccess.Data;
using WholeSaleManager.DataAccess.Repository.IRepository;
using WholeSaleManager.Models;
using System.Linq;

namespace WholeSaleManager.DataAccess.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private readonly ApplicationDbContext _db;

		public ProductRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Product product)
		{
			var obj = _db.Products.FirstOrDefault(c => c.Id == product.Id);

			if (obj != null)
			{
				obj.Name = product.Name;
				obj.Description = product.Description;
				obj.ListPrice = product.ListPrice;
				obj.Price = product.Price;
				obj.Price50 = product.Price50;
				obj.Price100 = product.Price100;
				obj.ImageUrl = product.ImageUrl;
				obj.CategoryId = product.CategoryId;
				obj.ManufacturerId = product.ManufacturerId;
				
				_db.SaveChanges();
			}
		}
	}
}
