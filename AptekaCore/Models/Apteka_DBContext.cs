using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AptekaCore.Models
{
    public partial class Apteka_DBContext : DbContext
    {
        public Apteka_DBContext()
        {
        }

        public Apteka_DBContext(DbContextOptions<Apteka_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Medicines> Medicines { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderMed> OrderMed { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Apteka_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("customers");

                entity.Property(e => e.CustId).HasColumnName("cust_ID");

                entity.Property(e => e.CustAdress)
                    .IsRequired()
                    .HasColumnName("cust_adress")
                    .HasMaxLength(50);

                entity.Property(e => e.CustLogin)
                    .IsRequired()
                    .HasColumnName("cust_login")
                    .HasMaxLength(50);

                entity.Property(e => e.CustMail)
                    .IsRequired()
                    .HasColumnName("cust_mail")
                    .HasMaxLength(50);

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasColumnName("cust_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CustPasswd)
                    .IsRequired()
                    .HasColumnName("cust_passwd")
                    .HasMaxLength(50);

                entity.Property(e => e.CustPhone).HasColumnName("cust_phone");

                entity.Property(e => e.CustSurname)
                    .IsRequired()
                    .HasColumnName("cust_surname")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("delivery");

                entity.Property(e => e.DeliveryId).HasColumnName("delivery_ID");

                entity.Property(e => e.DeliveryMethod)
                    .IsRequired()
                    .HasColumnName("delivery_method")
                    .HasColumnType("text");

                entity.Property(e => e.DeliveryStatus)
                    .HasColumnName("delivery_status")
                    .HasColumnType("text");

                entity.Property(e => e.DeliveryTrackNumber)
                    .HasColumnName("delivery_track_number")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmplId)
                    .HasName("PK_employees_1");

                entity.ToTable("employees");

                entity.Property(e => e.EmplId).HasColumnName("empl_ID");

                entity.Property(e => e.EmplHead)
                    .HasColumnName("empl_head")
                    .HasMaxLength(1);

                entity.Property(e => e.EmplLogin)
                    .IsRequired()
                    .HasColumnName("empl_login")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplMail)
                    .IsRequired()
                    .HasColumnName("empl_mail")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplName)
                    .IsRequired()
                    .HasColumnName("empl_name")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplPasswd)
                    .IsRequired()
                    .HasColumnName("empl_passwd")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplPhone).HasColumnName("empl_phone");

                entity.Property(e => e.EmplSurname)
                    .IsRequired()
                    .HasColumnName("empl_surname")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplTitle)
                    .IsRequired()
                    .HasColumnName("empl_title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Medicines>(entity =>
            {
                entity.HasKey(e => e.MedId);

                entity.ToTable("medicines");

                entity.Property(e => e.MedId).HasColumnName("med_ID");

                entity.Property(e => e.MedCat)
                    .IsRequired()
                    .HasColumnName("med_cat")
                    .HasMaxLength(50);

                entity.Property(e => e.MedDesc)
                    .IsRequired()
                    .HasColumnName("med_desc")
                    .HasMaxLength(50);

                entity.Property(e => e.MedInt).HasColumnName("med_int");

                entity.Property(e => e.MedName)
                    .IsRequired()
                    .HasColumnName("med_name")
                    .HasMaxLength(50);

                entity.Property(e => e.MedPrice)
                    .HasColumnName("med_price")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.MedQuant).HasColumnName("med_quant");

                entity.Property(e => e.MedReceipt).HasColumnName("med_receipt");

                entity.Property(e => e.VendorsId).HasColumnName("vendors_ID");

                entity.HasOne(d => d.Vendors)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.VendorsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_medicines_vendors");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId).HasColumnName("order_ID");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.CustomersId).HasColumnName("customers_ID");

                entity.Property(e => e.DeliveryId).HasColumnName("delivery_ID");

                entity.Property(e => e.OrderTime)
                    .HasColumnName("order_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentId).HasColumnName("payment_ID");

                entity.HasOne(d => d.Customers)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_customers");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.DeliveryId)
                    .HasConstraintName("FK_order_delivery");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_order_payment");
            });

            modelBuilder.Entity<OrderMed>(entity =>
            {
                entity.ToTable("order_med");

                entity.Property(e => e.OrderMedId).HasColumnName("order_med_ID");

                entity.Property(e => e.MedicinesId).HasColumnName("medicines_ID");

                entity.Property(e => e.OrderId).HasColumnName("order_ID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Medicines)
                    .WithMany(p => p.OrderMed)
                    .HasForeignKey(d => d.MedicinesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_med_medicines");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderMed)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_med_order");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.Property(e => e.PaymentId).HasColumnName("payment_ID");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasColumnName("payment_method")
                    .HasColumnType("text");

                entity.Property(e => e.PaymentNumber)
                    .HasColumnName("payment_number")
                    .HasColumnType("text");

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasColumnName("payment_status")
                    .HasColumnType("text");

                entity.Property(e => e.PaymentTime)
                    .HasColumnName("payment_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Vendors>(entity =>
            {
                entity.HasKey(e => e.VendId);

                entity.ToTable("vendors");

                entity.Property(e => e.VendId).HasColumnName("vend_ID");

                entity.Property(e => e.VendAdress)
                    .IsRequired()
                    .HasColumnName("vend_adress")
                    .HasMaxLength(50);

                entity.Property(e => e.VendName)
                    .IsRequired()
                    .HasColumnName("vend_name")
                    .HasMaxLength(50);

                entity.Property(e => e.VendPhone).HasColumnName("vend_phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
