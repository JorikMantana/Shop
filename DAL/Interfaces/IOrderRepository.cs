using System.Collections;
using DAL.Models;

namespace DAL.Interfaces;

public interface IOrderRepository
{
    Task CreateOrder(Order order);
    Task<IEnumerable<Order>> GetAllOrders();
    Task<Order> GetOrderById(int orderId);
    Task<IEnumerable<Order>> GetOrdersByUserId(string userId);
    Task DeleteOrder(int orderId);
}