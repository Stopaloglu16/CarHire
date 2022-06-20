using Domain.Entities.RoleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class RoleRoleGroupConfiguration : IEntityTypeConfiguration<RoleRoleGroup>
    {

        public void Configure(EntityTypeBuilder<RoleRoleGroup> builder)
        {
            builder.HasKey(e => new { e.RoleGroupId, e.RoleId });

            builder.Property(e => e.HaveSkillSince).HasDefaultValueSql("(getdate())");

            builder.HasOne(d => d.Role)
                    .WithMany(p => p.RoleRoleGroups)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleRoleGroup_Roles");

        }

    }
}
