using WholeSaleManager.DataAccess.Data;
using WholeSaleManager.DataAccess.Repository.IRepository;
using WholeSaleManager.Models;
using System.Linq;

namespace WholeSaleManager.DataAccess.Repository
{
	public class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository
	{
		private readonly ApplicationDbContext _db;

		public ManufacturerRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Manufacturer manufacturer)
		{
			var obj = _db.Manufacturers.FirstOrDefault(c => c.Id == manufacturer.Id);

			if (obj != null)
			{
				obj.Name = manufacturer.Name;
				_db.SaveChanges();
			}
		}
	}
}
