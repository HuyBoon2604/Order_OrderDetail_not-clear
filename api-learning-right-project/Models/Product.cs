﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_learning_right_project.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("ProductID")]
        [StringLength(10)]
        public string ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public bool Status { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}