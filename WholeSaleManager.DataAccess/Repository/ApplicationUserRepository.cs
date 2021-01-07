using WholeSaleManager.DataAccess.Data;
using WholeSaleManager.DataAccess.Repository.IRepository;
using WholeSaleManager.Models;
using System.Linq;

namespace WholeSaleManager.DataAccess.Repository
{
	public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
	{
		private readonly ApplicationDbContext _db;

		public ApplicationUserRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

	}
}
