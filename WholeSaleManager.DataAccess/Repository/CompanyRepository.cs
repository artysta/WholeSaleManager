using WholeSaleManager.DataAccess.Data;
using WholeSaleManager.DataAccess.Repository.IRepository;
using WholeSaleManager.Models;
using System.Linq;

namespace WholeSaleManager.DataAccess.Repository
{
	public class CompanyRepository : Repository<Company>, ICompanyRepository
	{
		private readonly ApplicationDbContext _db;

		public CompanyRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Company company)
		{
			_db.Update(company);
		}
	}
}
