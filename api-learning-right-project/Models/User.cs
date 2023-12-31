﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_learning_right_project.Models
{
    public partial class User
    {
        public User()
        {
            FeedBack = new HashSet<FeedBack>();
            Order = new HashSet<Order>();
            ProductCustom = new HashSet<ProductCustom>();
        }

        [Key]
        [Column("UserID")]
        [StringLength(10)]
        public string UserId { get; set; }
        [Required]
        [Column("RoelID")]
        [StringLength(10)]
        public string RoelId { get; set; }
        [Column("ImageURL")]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(20)]
        public string PassWord { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        public bool? Gender { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfBird { get; set; }
        [Required]
        [StringLength(70)]
        public string Address { get; set; }
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<FeedBack> FeedBack { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Order> Order { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ProductCustom> ProductCustom { get; set; }
    }
}