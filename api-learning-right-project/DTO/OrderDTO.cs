using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api_learning_right_project.DTO
{
    public class OrderDTO
    {
        public string orderId { get; set; }
      
        public string? userId { get; set; }
     
        public string? note { get; set; }
        public DateTime createDate { get; set; }
      
        public decimal total { get; set; }
        public bool status { get; set; }
    }
}
