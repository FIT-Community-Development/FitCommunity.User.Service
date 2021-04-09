﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Order.Database;

namespace Order.Database.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    [Migration("20210409083459_ConfigureDatabaseTablesž")]
    partial class ConfigureDatabaseTablesž
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Order.Domain.Buyer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("Name1");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("Order.Domain.CardType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CardTypes");
                });

            modelBuilder.Entity("Order.Domain.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OrderStatusId")
                        .HasColumnType("uuid")
                        .HasColumnName("OrderStatusId1");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("OrderDate");

                    b.Property<Guid>("orderStatusId")
                        .HasColumnType("uuid")
                        .HasColumnName("OrderStatusId");

                    b.Property<Guid>("paymentMethodId")
                        .HasColumnType("uuid")
                        .HasColumnName("PaymentMethodId");

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("orderStatusId");

                    b.HasIndex("paymentMethodId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Order.Domain.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("discount")
                        .HasColumnType("numeric")
                        .HasColumnName("Discount");

                    b.Property<string>("productImage")
                        .HasColumnType("text")
                        .HasColumnName("ProductImage");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ProductName");

                    b.Property<decimal>("unitPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("UnitPrice");

                    b.Property<int>("units")
                        .HasColumnType("integer")
                        .HasColumnName("Units");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Order.Domain.OrderStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("Order.Domain.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uuid");

                    b.Property<string>("cardHolderName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CardHolderName");

                    b.Property<string>("cardNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CardNumber");

                    b.Property<Guid>("cardTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("CardTypeId");

                    b.Property<DateTime>("expiration")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("Expiration");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("cardTypeId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Order.Domain.Order", b =>
                {
                    b.HasOne("Order.Domain.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId");

                    b.HasOne("Order.Domain.OrderStatus", null)
                        .WithMany()
                        .HasForeignKey("orderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Order.Domain.PaymentMethod", null)
                        .WithMany()
                        .HasForeignKey("paymentMethodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("Order.Domain.OrderItem", b =>
                {
                    b.HasOne("Order.Domain.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Order.Domain.PaymentMethod", b =>
                {
                    b.HasOne("Order.Domain.Buyer", null)
                        .WithMany("PaymentMethods")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Order.Domain.CardType", "CardType")
                        .WithMany()
                        .HasForeignKey("cardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardType");
                });

            modelBuilder.Entity("Order.Domain.Buyer", b =>
                {
                    b.Navigation("PaymentMethods");
                });

            modelBuilder.Entity("Order.Domain.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
