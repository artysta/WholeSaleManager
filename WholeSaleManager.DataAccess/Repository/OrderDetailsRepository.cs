using WholeSaleManager.DataAccess.Data;
using WholeSaleManager.DataAccess.Repository.IRepository;
using WholeSaleManager.Models;
using System.Linq;

namespace WholeSaleManager.DataAccess.Repository
{
	public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
	{
		private readonly ApplicationDbContext _db;

		public OrderDetailsRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(OrderDetails obj)
		{
			_db.Update(obj);
		}
	}
}
