﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebMinhaFinancas.Data;

namespace WebMinhaFinancas.Migrations
{
    [DbContext(typeof(WebMinhaFinancasContext))]
    [Migration("20220212171009_TypePayRemovedCampoIcon")]
    partial class TypePayRemovedCampoIcon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebMinhaFinancas.Models.Entitty.Icon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IconClass");

                    b.Property<string>("IconName");

                    b.HasKey("Id");

                    b.ToTable("Icon");
                });

            modelBuilder.Entity("WebMinhaFinancas.Models.Entitty.TypeFixedBill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdateAt");

                    b.HasKey("Id");

                    b.ToTable("TypeFixedBill");
                });

            modelBuilder.Entity("WebMinhaFinancas.Models.Entitty.TypePay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Flag");

                    b.Property<int>("IconId");

                    b.Property<DateTime?>("UpdateAt");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("IconId");

                    b.HasIndex("UserId");

                    b.ToTable("TypePay");
                });

            modelBuilder.Entity("WebMinhaFinancas.Models.Entitty.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime?>("CreateAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("Password");

                    b.Property<DateTime?>("UpdateAt");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebMinhaFinancas.Models.Entitty.TypePay", b =>
                {
                    b.HasOne("WebMinhaFinancas.Models.Entitty.Icon", "IconFont")
                        .WithMany("LTPay")
                        .HasForeignKey("IconId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebMinhaFinancas.Models.Entitty.User", "User")
                        .WithMany("LTyoePay")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}