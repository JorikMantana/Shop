using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }
    
    public async Task<IEnumerable<OrderDto>> GetAllOrders()
    {
        var orders = await _unitOfWork.Orders.GetAllOrders();
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto> GetOrderById(int orderId)
    {
        var order = _unitOfWork.Orders.GetOrderById(orderId);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task CreateOrder(OrderDto order)
    {
        var newOrder = _mapper.Map<Order>(order);
        await _unitOfWork.Orders.CreateOrder(newOrder);
        await _unitOfWork.SaveChanges();
    }

    public async Task<IEnumerable<OrderDto>> GetOrderByUserId(string userId)
    {
        var orders = _unitOfWork.Orders.GetOrdersByUserId(userId);
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task DeleteOrder(int orderId)
    {
        await _unitOfWork.Orders.DeleteOrder(orderId);
        await _unitOfWork.SaveChanges();
    }
}