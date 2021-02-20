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
		IShoppingCartRepository ShoppingCart { get; }
		IOrderHeaderRepository OrderHeader { get; }
		IOrderDetailsRepository OrderDetails { get; }
		void Save();
	}
}
