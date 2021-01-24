using WholeSaleManager.Models;

namespace WholeSaleManager.DataAccess.Repository.IRepository
{
	public interface IOrderHeaderRepository : IRepository<OrderHeader>
	{
		void Update(OrderHeader obj);
	}
}
