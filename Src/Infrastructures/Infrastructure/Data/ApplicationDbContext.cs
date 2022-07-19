
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities.AddressAggregate;
using Domain.Entities.BranchAggregate;
using Domain.Entities.CarAggregate;
using Domain.Entities.CarBrandsAggregate;
using Domain.Entities.CardDetailAggregate;
using Domain.Entities.CarExtraAggregate;
using Domain.Entities.CarHireAggregate;
using Domain.Entities.CarModelAggregate;
using Domain.Entities.RoleAggregate;
using Domain.Entities.UserAggregate;
using Domain.Enums;
using Infrastructure.CommonModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        private readonly ICurrentUserService _currentUserService;


#nullable disable
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
                                    ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public ApplicationDbContext()
        {
        }


#nullable enable

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CardDetail> CardDetails { get; set; }
        public DbSet<CarExtra> CarExtras { get; set; }
        public DbSet<CarHireObj> CarHires { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RoleGroup>()
                       .HasMany(s => s.Roles)
                       .WithMany(s => s.RoleGroups)
                       .UsingEntity<RoleRoleGroup>(j => j.HasOne(m => m.Role).WithMany(c => c.RoleRoleGroups),
                                                   j => j.HasOne(m => m.RoleGroup).WithMany(s => s.RoleRoleGroups));


            modelBuilder.Entity<RoleUser>(entity =>
            {
                entity.HasKey(e => new { e.RolesId, e.UsersId });

                entity.HasOne(d => d.Roles)
                    .WithMany(p => p.RoleUsers)
                    .HasForeignKey(d => d.RolesId)
                    .HasConstraintName("FK_RoleUser_Roles_RolesRoleId");
            });


            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.addressType)
                            .HasConversion(x => (int)x, x => (AddressType)x);
            });



            //modelBuilder.Entity<CarHire>(entity =>
            //{
            //    entity.HasOne(d => d.CarHirePickUpBranch)
            //        .WithMany(p => p.CarHirePickUpBranches)
            //        .HasForeignKey(d => d.PickUpBranchId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);

            //    entity.HasOne(d => d.CarHireReturnBranch)
            //        .WithMany(p => p.CarHireReturnBranches)
            //        .HasForeignKey(d => d.ReturnBranchId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);


            //});

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

        }



        public DbSet<Audit> AuditLogs { get; set; }



        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {

            
            if (_currentUserService != null)
            {
                var userId = _currentUserService.UserId;


                foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
                {
                    Console.WriteLine(entry.State);


                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedBy = _currentUserService.UserName; // _currentUserService.UserId;
                            entry.Entity.Created = DateTime.Now; // _dateTime.Now;
                            break;
                        case EntityState.Modified:
                            entry.Entity.LastModifiedBy = _currentUserService.UserName; // _currentUserService.UserId;
                            entry.Entity.LastModified = DateTime.Now;// _dateTime.Now;
                            break;
                    }
                }

                OnBeforeSaveChanges(userId);

            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }


        private void OnBeforeSaveChanges(string userId)
        {
            try
            {

                ChangeTracker.DetectChanges();
                var auditEntries = new List<AuditEntry>();
                foreach (var entry in ChangeTracker.Entries())
                {
                    if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                        continue;


                    var auditEntry = new CommonModel.AuditEntry(entry);
                    auditEntry.TableName = entry.Entity.GetType().Name;
                    auditEntry.UserId = userId;
                    auditEntries.Add(auditEntry);
                    foreach (var property in entry.Properties)
                    {
                        string propertyName = property.Metadata.Name;
                        if (property.Metadata.IsPrimaryKey())
                        {
                            auditEntry.KeyValues[propertyName] = property.CurrentValue;
                            continue;
                        }

                        switch (entry.State)
                        {
                            case EntityState.Added:

                                auditEntry.AuditType = Enums.AuditType.Create;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                                break;

                            case EntityState.Deleted:

                                auditEntry.AuditType = Enums.AuditType.Delete;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                break;

                            case EntityState.Modified:
                                if (property.IsModified)
                                {

                                    auditEntry.ChangedColumns.Add(propertyName);
                                    auditEntry.AuditType = Enums.AuditType.Update;
                                    auditEntry.OldValues[propertyName] = property.OriginalValue;
                                    auditEntry.NewValues[propertyName] = property.CurrentValue;
                                }
                                break;
                        }
                    }
                }

                foreach (var auditEntry in auditEntries)
                {
                    AuditLogs.Add(auditEntry.ToAudit());
                }

                Console.WriteLine(AuditLogs);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
