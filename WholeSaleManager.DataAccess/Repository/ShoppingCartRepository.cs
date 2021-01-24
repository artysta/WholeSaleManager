using WholeSaleManager.DataAccess.Data;
using WholeSaleManager.DataAccess.Repository.IRepository;
using WholeSaleManager.Models;
using System.Linq;

namespace WholeSaleManager.DataAccess.Repository
{
	public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
	{
		private readonly ApplicationDbContext _db;

		public ShoppingCartRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(ShoppingCart obj)
		{
			_db.Update(obj);
		}
	}
}
