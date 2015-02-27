using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZiJingHu.Models
{
    public class ZiJingHuContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
    public enum BusinessMode
    {
        [Display(Name = "合同能源管理EMC商业模式")]
        EMC = 1,
        [Display(Name = "工程总承包EPC模式")]
        EPC = 2,
        [Display(Name = "EP总承包模式")]
        EP = 3
    }
    public enum Category
    {
        [Display(Name = "政府")]
        Government = 0,
        [Display(Name = "金融")]
        Finance = 1,
        [Display(Name = "交通")]
        Transportation = 2,
        [Display(Name = "土建")]
        Others = 3,
        [Display(Name = "电力")]
        Electricity = 4,
        [Display(Name = "烟草")]
        Tobacco = 5,
        [Display(Name = "煤炭")]
        Coal = 6,
        [Display(Name = "石化")]
        Chemical = 7,
        [Display(Name = "环境")]
        Environment = 8
    }

    public class Product
    {
        public int Id { get; set; }

        [Required, Display(Name = "产品名称")]
        public string Name { get; set; }

        [Required, Display(Name = "产品类别")]
        public Category Category { get; set; }

        [Required, Display(Name = "产品简介"), AllowHtml]
        public string Description { get; set; }

        [Required, Display(Name = "产品详情"), AllowHtml]
        public string Detail { get; set; }

        [Display(Name = "图片")]
        public string ImageName { get; set; }

        public virtual List<Client> Clients { get; set; }

        [Required, Display(Name = "创建时间"), DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        public int? Sequence { get; set; }

    }

    public class Client
    {
        public int Id { get; set; }

        [Required, Display(Name = "客户名称")]
        public string Name { get; set; }

        [Required, Display(Name = "总部")]
        public string HeadQuarter { get; set; }

        [Required, Display(Name = "客户简介"), AllowHtml]
        public string Description { get; set; }

        [Display(Name = "客户使用反馈"), AllowHtml]
        public string Feedback { get; set; }

        [Required, ForeignKey("Product"), Display(Name = "客户使用产品")]
        public int ProductId { get; set; }

        [Display(Name = "图片")]
        public string ImageName { get; set; }

        public virtual Product Product { get; set; }

        public virtual List<Employee> Employees { get; set; }
        public int? Sequence { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }

        [Required, ForeignKey("Client")]
        public int ClientId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual Client Client { get; set; }
    }

    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? LastLogoffDate { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsDeleted { get; set; }

        public int FailedLoginTimes { get; set; }
        public virtual Employee Employee { get; set; }

    }

    public class Setting
    {
        public int Id { get; set; }

        [Required, Display(Name = "用户名")]
        public string Name { get; set; }

        [Required, Display(Name = "密码")]
        public string Value { get; set; }

        public string Description { get; set; }
    }

}