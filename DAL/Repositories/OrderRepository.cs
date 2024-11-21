using System.Collections;
using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ShopContext _context;

    public OrderRepository(ShopContext context)
    {
        _context = context;
    }
    
    public async Task CreateOrder(Order order)
    {
        await _context.Orders.AddAsync(order);
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> GetOrderById(int orderId)
    {
        return await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserId(string userName)
    {
        return await _context.Orders.Where(o => o.UserName == userName).ToListAsync();
    }

    public async Task DeleteOrder(int orderId)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        _context.Orders.Remove(order);
    }
}