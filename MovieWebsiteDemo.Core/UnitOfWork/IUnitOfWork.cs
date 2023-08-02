namespace MovieWebsiteDemo.Core.IUnitOfWork
{
    public interface IUnitOfWork
    {
        //SaveChange
        Task CommitAsync();
        void Commit();
    }
}
