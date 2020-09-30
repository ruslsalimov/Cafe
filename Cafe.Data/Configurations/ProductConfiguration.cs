using Cafe.Data.Models.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(key => key.Id)
                .HasName("quote_id");

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.Provider)
                .IsRequired();

            builder.Property(p => p.ProductType)
                .IsRequired();

            builder.HasData(new Product
            {
                Id = 1,
                Name = "Марагоджип Никарагуа", Price = 589m,
                Description = "Яркий вкус с оттенками красного яблока, пудры какао и цедрой апельсина",
                Provider = "Никарагуа",
                ProductType = ProductType.Coffee
            }, new Product
            {
                Id = 2,
                Name = "Бразилия Серрадо", Price = 259m,
                Description =
                    "Вкус без лишней кислотности с нотками жареных орехов, горького шоколада и карамели, ароматный и сбалансированный",
                Provider = "Бразилия",
                ProductType = ProductType.Coffee
            }, new Product
            {
                Id = 3,
                Name = "Гондурас Сан Маркос ", Price = 299m,
                Description = "Плотный, насыщенный кофе с шоколадными оттенками и сильным теплом",
                Provider = "Гондурас",
                ProductType = ProductType.Coffee
            }, new Product
            {
                Id = 4,
                Name = "Вьетнам Тай Нгуен", Price = 279,
                Description =
                    "Кофе средней крепости, с нотками шоколада, табака и специй и легкой цитрусовой кислотностью",
                Provider = "Вьетнам",
                ProductType = ProductType.Coffee
            }, new Product
            {
                Id = 5,
                Name = "Сенча", Price = 399,
                Description =
                    "Сенча — самый популярный зеленый чай в Японии, на него приходится около 80% всего производящегося на территории страны чая",
                Provider = "Япония",
                ProductType = ProductType.Tea
            }, new Product
            {
                Id = 6,
                Name = "Чун Ми", Price = 489,
                Description = "Классический зеленый чай из провинции Хунань",
                Provider = "Китай",
                ProductType = ProductType.Tea
            }, new Product
            {
                Id = 7,
                Name = "Молочный улун", Price = 679,
                Description = "Молочный улун считается одним из самых популярных улунов во всем мире",
                Provider = "Китай",
                ProductType = ProductType.Tea
            }, new Product
            {
                Id = 8,
                Name = "Английский завтрак", Price = 699,
                Description = "Терпкий вкус с пряными нотами и длительным цветочным",
                Provider = "Индия",
                ProductType = ProductType.Tea
            });
        }
    }
}