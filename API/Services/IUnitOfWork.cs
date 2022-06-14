using System;
using API.dao;

namespace API.Services
{
	public interface IUnitOfWork : IDisposable
	{
		/// IDisposable will allow to release the resource after trasanction
		IGenericRepository<T> CreateGenericRepository<T>() where T : class;

		/// Method Complete() saves changes to database and return number of changes
		Task<int> Complete();
	}
}

