
namespace tntroc.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private GOContext dataContext;
        public GOContext DataContext { get { return dataContext; } }
        public DatabaseFactory()
        {
            dataContext = new GOContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }


}
