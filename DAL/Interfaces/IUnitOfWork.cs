using DAL.Repositories;

namespace DAL.Interfaces;

public interface IUnitOfWork
{
    public IProductRepository Products { get; }
    public IImageRepository Images { get; }
    public IFeedbackRepository Feedbacks { get; }
    public ICategoryRepository Categories { get; }
    public IOrderRepository Orders { get; }
    public Task SaveChanges();
}