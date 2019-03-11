
namespace tntroc.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
	{

		private GOContext dataContext;

		IDatabaseFactory dbFactory;
		public UnitOfWork(IDatabaseFactory dbFactory)
		{
			this.dbFactory = dbFactory;
			dataContext = dbFactory.DataContext;
		}

		public void Commit()
		{
			dataContext.SaveChanges();
		}
		public void Dispose()
		{
			dataContext.Dispose();
		}
		public IRepository<T> GetRepository<T>() where T : class
		{
			IRepository<T> repo = new RepositoryBase<T>(dbFactory);
			return repo;
		}



	}
}
