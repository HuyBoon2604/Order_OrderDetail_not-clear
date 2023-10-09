using api_learning_right_project.DTO;
using api_learning_right_project.Interface;
using api_learning_right_project.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace api_learning_right_project.Service
{
    public class OrderDetailService : IOrderDetail
    {
        private readonly BCSDbContext _context;

        public OrderDetailService(BCSDbContext context)
        {
            _context = context;
        }

        public async Task<OrderDetail> AddOrderDetailAsync(OrderDetailDTO orderDetailDTO)
        {
            try
            {
                // Kiểm tra xem OrderId, ProductId và FeedbackId có tồn tại trong hệ thống không
                var order = await this._context.Order.FindAsync(orderDetailDTO.OrderId);
                var product = await this._context.Product.FindAsync(orderDetailDTO.ProductId);

                if (order == null)
                {
                    throw new Exception("OrderId not found in the system.");
                }

                if (product == null)
                {
                    throw new Exception("ProductId not found in the system.");
                }


                var newOrderDetail = new OrderDetail();

                // Gán các giá trị cho các trường của đối tượng OrderDetail
                newOrderDetail.OrderId = orderDetailDTO.OrderId;
                newOrderDetail.ProductId = orderDetailDTO.ProductId;
                newOrderDetail.FeedbackId = orderDetailDTO.FeedbackId;
                newOrderDetail.Quantity = orderDetailDTO.Quantity;
                newOrderDetail.Price = orderDetailDTO.Price;
                newOrderDetail.IsCustom = orderDetailDTO.IsCustom;

                // Xử lý trường Status
                if (!orderDetailDTO.IsCustom)
                {
                    newOrderDetail.Status = true; // Đặt Status thành true nếu không tùy chỉnh
                }
                else
                {
                    newOrderDetail.Status = false; // Đặt Status thành false nếu tùy chỉnh
                }

                await this._context.OrderDetail.AddAsync(newOrderDetail);
                await this._context.SaveChangesAsync();

                return newOrderDetail;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và thông báo lỗi tương ứng
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
                throw new Exception($"Failed to create Order Detail: {ex.Message}");
            }
        }

        public async Task<bool> DeleteOrderDetailAsync(string id)
        {
            bool isDelete = false;
            try
            {
                // Tìm bản ghi Voucher theo VoucherID
                var OrderDetailToDelete = await this._context.OrderDetail.FirstOrDefaultAsync(v => v.OrderId == id);

                if (OrderDetailToDelete != null)
                {
                    // Xóa bản ghi Voucher nếu tìm thấy
                    this._context.OrderDetail.Remove(OrderDetailToDelete);
                    await this._context.SaveChangesAsync();
                    isDelete = true;
                }
                else
                {
                    throw new Exception($"Failed to delete");
                    isDelete = true;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete: {ex.Message}");
            }
            return isDelete;
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(string id)
        {
            try
            {
                // Tìm bản ghi Voucher dựa trên VoucherName
                var find = await this._context.OrderDetail.FirstOrDefaultAsync(v => v.OrderId == id);

                if (find == null)
                {
                    // Nếu không tìm thấy, trả về null hoặc có thể xử lý tùy theo yêu cầu của bạn
                    return null;
                }

                return find;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và thông báo lỗi tương ứng
                throw new Exception($"Failed to get Voucher by name: {ex.Message}");
            }
        }
        public async Task<List<OrderDetail>> GetAllOrderDetailsAsync()
        {
            try
            {
                var list = await this._context.OrderDetail.Select(x => new OrderDetail
                {
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,
                    FeedbackId = x.FeedbackId,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Status = x.Status,
                    IsCustom = x.IsCustom,

                }).ToListAsync();
                if (list != null)
                {
                    return list;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> UpdateOrderDetailAsync(string id)
        {
            try
            {
                var orderDetail = await this._context.OrderDetail.FirstOrDefaultAsync(x => x.OrderId == id);
                if (orderDetail != null)
                {
                    if (orderDetail.IsCustom)
                    {
                        if (orderDetail.IsCustom == true)
                        {
                            orderDetail.IsCustom = false;
                            await this._context.SaveChangesAsync();
                            return true;
                        }   
                        
                    }
                    else
                    {
                        if(orderDetail.Status == true) { }
                       
                        orderDetail.Status = false;
                        await this._context.SaveChangesAsync();
                        return true;
                    }
              
                }
                throw new Exception("Cannot find Order ID");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update status: {ex.Message}");
            }
        }
    }
}
