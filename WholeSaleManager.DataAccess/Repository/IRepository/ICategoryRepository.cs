using WholeSaleManager.Models;

namespace WholeSaleManager.DataAccess.Repository.IRepository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void Update(Category category);
	}
}
