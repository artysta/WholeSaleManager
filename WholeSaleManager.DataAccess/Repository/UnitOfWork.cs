﻿using WholeSaleManager.DataAccess.Data;
using WholeSaleManager.DataAccess.Repository.IRepository;

namespace WholeSaleManager.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;

		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Category = new CategoryRepository(_db);
			Company = new CompanyRepository(_db);
			Manufacturer = new ManufacturerRepository(_db);
			Product = new ProductRepository(_db);
			ApplicationUser = new ApplicationUserRepository(_db);
			ShoppingCart = new ShoppingCartRepository(_db);
			OrderHeader = new OrderHeaderRepository(_db);
			OrderDetails = new OrderDetailsRepository(_db);
		}

		public ICategoryRepository Category { get; private set; }
		public ICompanyRepository Company { get; private set; }
		public IManufacturerRepository Manufacturer { get; private set; }
		public IProductRepository Product { get; private set; }
		public IApplicationUserRepository ApplicationUser { get; private set; }

		public IShoppingCartRepository ShoppingCart { get; private set; }
		public IOrderHeaderRepository OrderHeader { get; private set; }
		public IOrderDetailsRepository OrderDetails { get; private set; }

		public void Dispose()
		{
			_db.Dispose();
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
