using WholeSaleManager.Models;

namespace WholeSaleManager.DataAccess.Repository.IRepository
{
	public interface IManufacturerRepository : IRepository<Manufacturer>
	{
		void Update(Manufacturer manufacturer);
	}
}
