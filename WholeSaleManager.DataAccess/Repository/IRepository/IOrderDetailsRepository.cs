using WholeSaleManager.Models;

namespace WholeSaleManager.DataAccess.Repository.IRepository
{
	public interface IOrderDetailsRepository : IRepository<OrderDetails>
	{
		void Update(OrderDetails obj);
	}
}
