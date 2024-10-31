using DAL.Repositories;

namespace DAL.Interfaces;

public interface IUnitOfWork
{
    public IProductRepository Products { get; }
    public IImageRepository Images { get; }
    public Task SaveChanges();
}