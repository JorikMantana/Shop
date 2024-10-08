using DAL.Repositories;

namespace DAL.Interfaces;

public interface IUnitOfWork
{
    public IProductRepository Products { get; }
    public Task SaveChanges();
}