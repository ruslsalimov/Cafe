using Cafe.Data.Models.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(key => key.Id)
                .HasName("review_id");
            
            builder.Property(p => p.Text)
                .IsRequired();
            
            builder.Property(p => p.DateTime)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP()");
        }
    }
}