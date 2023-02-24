namespace Application.BaseGetData.UniteOfWork
{
    public interface IUniteOfWork
    {
        Task<int> SaveChangesAsync();
        void SaveChanges();
    }
}
