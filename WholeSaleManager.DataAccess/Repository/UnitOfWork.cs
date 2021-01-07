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
			SP_Call = new SP_Call(_db);
		}

		public ICategoryRepository Category { get; private set; }
		public ICompanyRepository Company { get; private set; }
		public IManufacturerRepository Manufacturer { get; private set; }
		public IProductRepository Product { get; private set; }
		public ISP_Call SP_Call { get; private set; }

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
