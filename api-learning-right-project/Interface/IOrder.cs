using api_learning_right_project.DTO;
using api_learning_right_project.Models;

namespace api_learning_right_project.Interface
{
    public interface IOrder
    {
        public  Task<List<Order>> GetAllOrdersAsync();
        public Task<Order> GetOrderByIdAsync(string id);
        public Task<Order> AddOrderAsync(OrderDTO order);
        public Task<bool> DeleteOrderAsync(string id);
        public Task<bool> UpdateOrderAsync(string id);
    }
}
