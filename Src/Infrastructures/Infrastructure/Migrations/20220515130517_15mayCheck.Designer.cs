﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220515130517_15mayCheck")]
    partial class _15mayCheck
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.AddressAggregate.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int>("addressType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Domain.Entities.BranchAggregate.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Domain.Entities.CarAggregate.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<decimal>("Costperday")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gearbox")
                        .HasColumnType("int");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("NumberPlates")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CarModelId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Domain.Entities.CarBrandsAggregate.CarBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CarBrands");
                });

            modelBuilder.Entity("Domain.Entities.CardDetailAggregate.CardDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CardDetails");
                });

            modelBuilder.Entity("Domain.Entities.CarExtraAggregate.CarExtra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CarExtras");
                });

            modelBuilder.Entity("Domain.Entities.CarHireAggregate.CarHire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("BookingCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarHirePickUpBranchId")
                        .HasColumnType("int");

                    b.Property<int>("CarHireReturnBranchId")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PickUpBranchId")
                        .HasColumnType("int");

                    b.Property<bool>("PickUpConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PickUpDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PickUpDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReturnBranchId")
                        .HasColumnType("int");

                    b.Property<bool>("ReturnConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReturnMileage")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarHirePickUpBranchId");

                    b.HasIndex("CarHireReturnBranchId");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("CarHires");
                });

            modelBuilder.Entity("Domain.Entities.CarModelAggregate.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarBrandId")
                        .HasColumnType("int");

                    b.Property<string>("CarPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CarPhotoLenght")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarBrandId");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("Domain.Entities.RoleAggregate.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleDisplayName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("RoleTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SystemFeatureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Entities.RoleAggregate.RoleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleGroupName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("UserTypeID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RoleGroup");
                });

            modelBuilder.Entity("Domain.Entities.RoleAggregate.RoleRoleGroup", b =>
                {
                    b.Property<int>("RoleGroupId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HaveSkillSince")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("RoleGroupId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleRoleGroup");
                });

            modelBuilder.Entity("Domain.Entities.RoleAggregate.RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("AspId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int?>("CardDetailId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegisterToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterTokenValid")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleGroupId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.Property<int>("userType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("BranchId");

                    b.HasIndex("CardDetailId");

                    b.HasIndex("RoleGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Infrastructure.CommonModel.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AffectedColumns")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewValues")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValues")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("Domain.Entities.BranchAggregate.Branch", b =>
                {
                    b.HasOne("Domain.Entities.AddressAggregate.Address", "Address")
                        .WithMany("Branches")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Domain.Entities.CarAggregate.Car", b =>
                {
                    b.HasOne("Domain.Entities.BranchAggregate.Branch", "Branch")
                        .WithMany("Cars")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CarModelAggregate.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("Domain.Entities.CarHireAggregate.CarHire", b =>
                {
                    b.HasOne("Domain.Entities.BranchAggregate.Branch", "CarHirePickUpBranch")
                        .WithMany("CarHirePickUpBranches")
                        .HasForeignKey("CarHirePickUpBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.BranchAggregate.Branch", "CarHireReturnBranch")
                        .WithMany("CarHireReturnBranches")
                        .HasForeignKey("CarHireReturnBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CarAggregate.Car", "Car")
                        .WithMany("CarHires")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserAggregate.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("CarHirePickUpBranch");

                    b.Navigation("CarHireReturnBranch");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.CarModelAggregate.CarModel", b =>
                {
                    b.HasOne("Domain.Entities.CarBrandsAggregate.CarBrand", "CarBrand")
                        .WithMany("CarModels")
                        .HasForeignKey("CarBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarBrand");
                });

            modelBuilder.Entity("Domain.Entities.RoleAggregate.RoleRoleGroup", b =>
                {
                    b.HasOne("Domain.Entities.RoleAggregate.RoleGroup", "RoleGroup")
                        .WithMany("RoleRoleGroups")
                        .HasForeignKey("RoleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.RoleAggregate.Role", "Role")
                        .WithMany("RoleRoleGroups")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_RoleRoleGroup_Roles");

                    b.Navigation("Role");

                    b.Navigation("RoleGroup");
                });

            modelBuilder.Entity("Domain.Entities.RoleAggregate.RoleUser", b =>
                {
                    b.HasOne("Domain.Entities.RoleAggregate.Role", "Roles")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_RoleUser_Roles_RolesRoleId");

                    b.HasOne("Domain.Entities.UserAggregate.User", "Users")
                        .WithMany("RoleUsers")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.UserAggregate.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.User", b =>
                {
                    b.HasOne("Domain.Entities.AddressAggregate.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId");

                    b.HasOne("Domain.Entities.BranchAggregate.Branch", "Branch")
                        .WithMany("Users")
                        .HasForeignKey("BranchId");

                    b.HasOne("Domain.Entities.CardDetailAggregate.CardDetail", "CardDetail")
                        .WithMany("Users")
                        .HasForeignKey("CardDetailId");

                    b.HasOne("Domain.Entities.RoleAggregate.RoleGroup", "RoleGroup")
                        .WithMany("Users")
                        .HasForeignKey("RoleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Branch");

                    b.Navigation("CardDetail");

                    b.Navigation("RoleGroup");
                });

            modelBuilder.Entity("Domain.Entities.AddressAggregate.Address", b =>
                {
                    b.Navigation("Branches");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.BranchAggregate.Branch", b =>
                {
                    b.Navigation("CarHirePickUpBranches");

                    b.Navigation("CarHireReturnBranches");

                    b.Navigation("Cars");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.CarAggregate.Car", b =>
                {
                    b.Navigation("CarHires");
                });

            modelBuilder.Entity("Domain.Entities.CarBrandsAggregate.CarBrand", b =>
                {
                    b.Navigation("CarModels");
                });

            modelBuilder.Entity("Domain.Entities.CardDetailAggregate.CardDetail", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.RoleAggregate.Role", b =>
                {
                    b.Navigation("RoleRoleGroups");

                    b.Navigation("RoleUsers");
                });

            modelBuilder.Entity("Domain.Entities.RoleAggregate.RoleGroup", b =>
                {
                    b.Navigation("RoleRoleGroups");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("RoleUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
