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
    [Migration("20220206032615_incial")]
    partial class incial
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

                    b.Property<string>("icon");

                    b.Property<string>("iconName");

                    b.HasKey("Id");

                    b.ToTable("Icon");
                });

            modelBuilder.Entity("WebMinhaFinancas.Models.Entitty.TypePay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Flag");

                    b.Property<string>("Icon");

                    b.Property<int?>("IconFontId");

                    b.Property<DateTime?>("UpdateAt");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("IconFontId");

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
                        .HasForeignKey("IconFontId");

                    b.HasOne("WebMinhaFinancas.Models.Entitty.User", "User")
                        .WithMany("LTyoePay")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}