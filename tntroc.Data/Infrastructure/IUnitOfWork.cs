using System;


namespace tntroc.Data.Infrastructure
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<T> GetRepository<T>() where T : class;
		void Commit();

	}

}
