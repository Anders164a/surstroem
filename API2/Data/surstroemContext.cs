﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using surstroem.Models;

#nullable disable

namespace surstroem.Data
{
    public partial class surstroemContext : DbContext
    {
        public surstroemContext()
        {
        }

        public surstroemContext(DbContextOptions<surstroemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DeliveryState> DeliveryStates { get; set; }
        public virtual DbSet<DeliveryType> DeliveryTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeHasShift> EmployeeHasShifts { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<PostalCode> PostalCodes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ReviewOpinion> ReviewOpinions { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseType> WarehouseTypes { get; set; }
        public virtual DbSet<WarrantyPeriod> WarrantyPeriods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_danish_ci");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasIndex(e => e.PostalCodeId, "postal_code_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Additional)
                    .HasMaxLength(50)
                    .HasColumnName("additional");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Floor)
                    .HasMaxLength(50)
                    .HasColumnName("floor");

                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(10)
                    .HasColumnName("house_number");

                entity.Property(e => e.PostalCodeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("postal_code_id");

                entity.Property(e => e.StreetName)
                    .HasMaxLength(100)
                    .HasColumnName("street_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.PostalCode)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.PostalCodeId)
                    .HasConstraintName("address_ibfk_1");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(20)
                    .HasColumnName("brand_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.HasIndex(e => e.ParentCategoryId, "parent_category_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Category1)
                    .HasMaxLength(50)
                    .HasColumnName("category");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.ParentCategoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("parent_category_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("categories_ibfk_1");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("colors");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Country1)
                    .HasMaxLength(60)
                    .HasColumnName("country");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<DeliveryState>(entity =>
            {
                entity.ToTable("delivery_states");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .HasColumnName("state");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<DeliveryType>(entity =>
            {
                entity.ToTable("delivery_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("departments");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AddressId)
                    .HasColumnType("int(11)")
                    .HasColumnName("address_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("department_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.Property(e => e.WorkPhone)
                    .HasColumnType("int(15)")
                    .HasColumnName("work_phone");
            });

            modelBuilder.Entity<EmployeeHasShift>(entity =>
            {
                entity.ToTable("employee_has_shift");

                entity.HasIndex(e => e.EmployeeId, "employee_id");

                entity.HasIndex(e => e.ShiftsId, "shifts_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("employee_id");

                entity.Property(e => e.ShiftsId)
                    .HasColumnType("int(11)")
                    .HasColumnName("shifts_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeHasShifts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("employee_has_shift_ibfk_2");

                entity.HasOne(d => d.Shifts)
                    .WithMany(p => p.EmployeeHasShifts)
                    .HasForeignKey(d => d.ShiftsId)
                    .HasConstraintName("employee_has_shift_ibfk_1");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("logs");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Info)
                    .HasColumnType("text")
                    .HasColumnName("info");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.DeliveryStateId, "delivery_state_id");

                entity.HasIndex(e => e.DeliveryTypeId, "delivery_type_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.DeliveryStateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("delivery_state_id");

                entity.Property(e => e.DeliveryTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("delivery_type_id");

                entity.Property(e => e.PayingAddress)
                    .HasColumnType("int(11)")
                    .HasColumnName("paying_address");

                entity.Property(e => e.ShippingAddress)
                    .HasColumnType("int(11)")
                    .HasColumnName("shipping_address");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.DeliveryState)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryStateId)
                    .HasConstraintName("orders_ibfk_2");

                entity.HasOne(d => d.DeliveryType)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryTypeId)
                    .HasConstraintName("orders_ibfk_1");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.ToTable("order_products");

                entity.HasIndex(e => e.OrderId, "order_id");

                entity.HasIndex(e => e.ProductsId, "products_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("order_id");

                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");

                entity.Property(e => e.ProductsId)
                    .HasColumnType("int(11)")
                    .HasColumnName("products_id");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("order_products_ibfk_2");

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductsId)
                    .HasConstraintName("order_products_ibfk_1");
            });

            modelBuilder.Entity<PostalCode>(entity =>
            {
                entity.ToTable("postal_codes");

                entity.HasIndex(e => e.CountryId, "country_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CityName)
                    .HasMaxLength(100)
                    .HasColumnName("city_name");

                entity.Property(e => e.CountryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("country_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.PostalCode1)
                    .HasMaxLength(10)
                    .HasColumnName("postal_code");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.PostalCodes)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("postal_codes_ibfk_1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.BrandId, "brand_id");

                entity.HasIndex(e => e.ColorId, "color_id");

                entity.HasIndex(e => e.WarrantyPeriodId, "warranty_period_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.BrandId)
                    .HasColumnType("int(11)")
                    .HasColumnName("brand_id");

                entity.Property(e => e.ColorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("color_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");

                entity.Property(e => e.ProductTitle)
                    .HasMaxLength(200)
                    .HasColumnName("product_title");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(200)
                    .HasColumnName("short_description");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.WarrantyPeriodId)
                    .HasColumnType("int(11)")
                    .HasColumnName("warranty_period_id");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("products_ibfk_2");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("products_ibfk_3");

                entity.HasOne(d => d.WarrantyPeriod)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.WarrantyPeriodId)
                    .HasConstraintName("products_ibfk_1");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("product_categories");

                entity.HasIndex(e => e.ProductId, "product_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("category_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("product_categories_ibfk_1");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("reviews");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnType("text")
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id");

                entity.Property(e => e.Star)
                    .HasColumnType("double(3,1)")
                    .HasColumnName("star");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<ReviewOpinion>(entity =>
            {
                entity.ToTable("review_opinion");

                entity.HasIndex(e => e.ReviewId, "review_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.IsDisliked).HasColumnName("is_disliked");

                entity.Property(e => e.IsLiked).HasColumnName("is_liked");

                entity.Property(e => e.ReviewId)
                    .HasColumnType("int(11)")
                    .HasColumnName("review_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewOpinions)
                    .HasForeignKey(d => d.ReviewId)
                    .HasConstraintName("review_opinion_ibfk_1");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("shifts");

                entity.HasIndex(e => e.DepartmentId, "department_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("department_id");

                entity.Property(e => e.ShiftEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("shift_end");

                entity.Property(e => e.ShiftStart)
                    .HasColumnType("datetime")
                    .HasColumnName("shift_start");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("shifts_ibfk_1");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("stocks");

                entity.HasIndex(e => e.ProductId, "product_id");

                entity.HasIndex(e => e.WarehouseId, "warehouse_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.WarehouseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("warehouse_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("stocks_ibfk_1");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("stocks_ibfk_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.AddressId, "address_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AddressId)
                    .HasColumnType("int(11)")
                    .HasColumnName("address_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .HasMaxLength(60)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("int(15)")
                    .HasColumnName("phone_number");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("users_ibfk_1");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("warehouses");

                entity.HasIndex(e => e.DepartmentId, "department_id");

                entity.HasIndex(e => e.WarehouseTypeId, "warehouse_type_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("department_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.WarehouseTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("warehouse_type_id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("warehouses_ibfk_2");

                entity.HasOne(d => d.WarehouseType)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.WarehouseTypeId)
                    .HasConstraintName("warehouses_ibfk_1");
            });

            modelBuilder.Entity<WarehouseType>(entity =>
            {
                entity.ToTable("warehouse_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<WarrantyPeriod>(entity =>
            {
                entity.ToTable("warranty_periods");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.WarrantyPeriod1)
                    .HasColumnType("double(2,2)")
                    .HasColumnName("warranty_period");

                entity.Property(e => e.WarrantyType)
                    .HasMaxLength(100)
                    .HasColumnName("warranty_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
