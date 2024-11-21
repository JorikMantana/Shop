using BLL.DTOs;
using DAL.Models;

namespace BLL.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllOrders();
    Task<OrderDto> GetOrderById(int orderId);
    Task CreateOrder(OrderDto order);
    Task<IEnumerable<OrderDto>> GetOrderByUserId(string userId);
    Task DeleteOrder(int orderId);
}