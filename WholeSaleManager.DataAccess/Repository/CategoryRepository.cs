using WholeSaleManager.DataAccess.Data;
using WholeSaleManager.DataAccess.Repository.IRepository;
using WholeSaleManager.Models;
using System.Linq;

namespace WholeSaleManager.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly ApplicationDbContext _db;

		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Category category)
		{
			var obj = _db.Categories.FirstOrDefault(c => c.Id == category.Id);

			if (obj != null)
			{
				obj.Name = category.Name;
				_db.SaveChanges();
			}
		}
	}
}
