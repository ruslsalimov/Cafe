using System.ComponentModel.DataAnnotations;

namespace Cafe.Data.Models.Models.Products
{
    public enum ProductType : int
    {
        [Display(Name = "Кофе")]
        Coffee,
        [Display(Name = "Чай")]
        Tea
    }
}