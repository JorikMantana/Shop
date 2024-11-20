namespace DAL.Interfaces;

public interface IIdentityUnitOfWork
{
    public IUserRepository Users { get; }
    Task SaveAsync();
}