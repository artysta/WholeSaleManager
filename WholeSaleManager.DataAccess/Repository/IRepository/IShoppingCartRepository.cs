using WholeSaleManager.Models;

namespace WholeSaleManager.DataAccess.Repository.IRepository
{
	public interface IShoppingCartRepository : IRepository<ShoppingCart>
	{
		void Update(ShoppingCart obj);
	}
}
