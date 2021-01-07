using System;

namespace WholeSaleManager.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork : IDisposable
	{
		ICategoryRepository Category { get; }
		ICompanyRepository Company { get; }
		IManufacturerRepository Manufacturer { get; }
		IProductRepository Product { get; }
		IApplicationUserRepository ApplicationUser { get; }
		ISP_Call SP_Call { get; }
		void Save();
	}
}
