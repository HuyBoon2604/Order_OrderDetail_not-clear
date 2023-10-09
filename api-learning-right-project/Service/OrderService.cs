using api_learning_right_project.DTO;
using api_learning_right_project.Interface;
using api_learning_right_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using static System.Reflection.Metadata.BlobBuilder;

namespace api_learning_right_project.Service
{
    public class OrderService : IOrder
    {
        private readonly BCSDbContext _context;

        public OrderService(BCSDbContext context)
        {
            _context = context;
        }


        public async Task<Order> AddOrderAsync(OrderDTO order)
        {
          
                try
                {
                var NewO = new Order();
                NewO.UserId = order.userId;
                NewO.OrderId = order.orderId;
                NewO.Note = order.note;
                NewO.CreateDate = order.createDate;
                NewO.Total = order.total;
                NewO.Status = true;

                    await this._context.Order.AddAsync(NewO);
                    await this._context.SaveChangesAsync();

                    return NewO;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to Add New {ex.Message}");
                }
            }





        public async Task<bool> DeleteOrderAsync(string id)
        {
            bool isDelete = false;
            try
            {
                // Tìm bản ghi Voucher theo VoucherID
                var orderToDelete = await this._context.Order.FirstOrDefaultAsync(v => v.OrderId == id);

                if (orderToDelete != null)
                {
                    // Xóa bản ghi Voucher nếu tìm thấy
                    this._context.Order.Remove(orderToDelete);
                    await this._context.SaveChangesAsync();
                    isDelete = true;
                }
              
            }catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            return isDelete;
        }



        public async Task<List<Order>> GetAllOrdersAsync()
        {
            try
            {
                var orders = await this._context.Order.Select(x => new Order
                {
                    UserId = x.UserId,
                    OrderId = x.OrderId,
                    Note = x.Note,
                    CreateDate = x.CreateDate,
                    Status = x.Status,
                    Total = x.Total,
                  
                
                }).ToListAsync();
                if (orders != null)
                {
                    return orders;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
           
        }

      

        public async Task<Order> GetOrderByIdAsync(string id)
        {
            try
            {
                // Tìm bản ghi Voucher dựa trên id
                var find = await this._context.Order.FirstOrDefaultAsync(v => v.OrderId == id);

                if (find == null)
                {
                    // Nếu không tìm thấy, trả về null hoặc có thể xử lý tùy theo yêu cầu của bạn
                    throw new Exception($"khong tim thay {id}: not found");
                }

                return find;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và thông báo lỗi tương ứng
                throw new Exception($"Failed to get Order by id: {ex.Message}");
            }
        }

        public async Task<bool> UpdateOrderAsync(string id)
        {
            try
            {
                var order = await this._context.Order.FirstOrDefaultAsync(x => x.OrderId == id);
                if (order != null)
                {

                    order.Status = false;
                    await this._context.SaveChangesAsync();
                    
                }
                    return false; // Quantity and Count are not equal
                
                throw new Exception("Cannot find VoucherName");
            } catch (Exception ex)
            {
                throw new Exception($"Failed to update status: {ex.Message}");
            }
        }
    }
}
