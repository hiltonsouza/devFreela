using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           builder
            .HasKey(u => u.Id);

           builder
                .HasMany(s => s.Skills)
                .WithOne()
                .HasForeignKey(s => s.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
