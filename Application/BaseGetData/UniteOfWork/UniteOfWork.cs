using Persistance.Context;

namespace Application.BaseGetData.UniteOfWork
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly DataContext _dataContext;

        public UniteOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}
