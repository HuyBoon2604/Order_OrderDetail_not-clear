using api_learning_right_project.DTO;
using api_learning_right_project.Models;

namespace api_learning_right_project.Interface
{
    public interface IOrderDetail
    {
        public Task<List<OrderDetail>> GetAllOrderDetailsAsync();
        public Task<OrderDetail> GetOrderDetailByIdAsync(string id);
        public Task<OrderDetail> AddOrderDetailAsync(OrderDetailDTO orderDetailDTO);
        public Task<bool> DeleteOrderDetailAsync(string id);
        public Task<bool> UpdateOrderDetailAsync(string id);
    }
}
