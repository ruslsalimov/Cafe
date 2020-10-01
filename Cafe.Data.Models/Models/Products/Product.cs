using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Cafe.Data.Models.Models.Products
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "Введите название")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Введите цену")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше 0")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Введите тип")]
        public ProductType ProductType { get; set; }
        
        [Required(ErrorMessage = "Введите описание поставщика")]
        public string Provider { get; set; }

        public string FotoSrc { get; set; } = "/images/napitok.jpg";
    }
}