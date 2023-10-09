using api_learning_right_project.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api_learning_right_project.DTO
{
    public class OrderDetailDTO
    {
        public string OrderId { get; set; }
    
        public string ProductId { get; set; }
     
        public string? FeedbackId { get; set; }
        public int Quantity { get; set; }
      
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public bool IsCustom { get; set; }

      
    }
}
