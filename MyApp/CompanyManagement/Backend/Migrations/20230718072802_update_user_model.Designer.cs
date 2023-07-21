﻿// <auto-generated />
using System;
using CompanyManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(CompanyManagementDbContext))]
    [Migration("20230718072802_update_user_model")]
    partial class update_user_model
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompanyManagement.Models.Address", b =>
                {
                    b.Property<string>("address_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ward_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.HasKey("address_id");

                    b.ToTable("addresse");
                });

            modelBuilder.Entity("CompanyManagement.Models.Announcement", b =>
                {
                    b.Property<string>("annc_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime");

                    b.Property<string>("department_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("user_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.HasKey("annc_id");

                    b.ToTable("announcement");
                });

            modelBuilder.Entity("CompanyManagement.Models.Department", b =>
                {
                    b.Property<string>("department_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("department_name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte>("floor")
                        .HasColumnType("tinyint");

                    b.HasKey("department_id");

                    b.ToTable("department");
                });

            modelBuilder.Entity("CompanyManagement.Models.District", b =>
                {
                    b.Property<string>("district_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("district_name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("province_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.HasKey("district_id");

                    b.ToTable("district");
                });

            modelBuilder.Entity("CompanyManagement.Models.FingerPrinting", b =>
                {
                    b.Property<string>("user_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("date")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("comein_time")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("comeout_time")
                        .HasColumnType("datetime");

                    b.HasKey("user_id", "date");

                    b.ToTable("fingerprinting");
                });

            modelBuilder.Entity("CompanyManagement.Models.Level", b =>
                {
                    b.Property<string>("level_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("level_name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("level_id");

                    b.ToTable("level");
                });

            modelBuilder.Entity("CompanyManagement.Models.Province", b =>
                {
                    b.Property<string>("province_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("province_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("province_id");

                    b.ToTable("province");
                });

            modelBuilder.Entity("CompanyManagement.Models.Requirement", b =>
                {
                    b.Property<string>("requirement_id")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime");

                    b.Property<string>("from_user")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("request_message")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("to_user")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("requirement_id");

                    b.ToTable("requirement");
                });

            modelBuilder.Entity("CompanyManagement.Models.Role", b =>
                {
                    b.Property<string>("role_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("role_name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("role_id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("CompanyManagement.Models.Schedule", b =>
                {
                    b.Property<string>("schedule_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("time_end")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("time_start")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("user_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.HasKey("schedule_id");

                    b.ToTable("schedule");
                });

            modelBuilder.Entity("CompanyManagement.Models.User", b =>
                {
                    b.Property<string>("user_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("birth_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("date_end")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("date_start")
                        .HasColumnType("datetime");

                    b.Property<string>("department_id")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("bit");

                    b.Property<string>("level_id")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("password_hash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("phone_number")
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("role_id")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<double>("salary")
                        .HasColumnType("float");

                    b.Property<string>("street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ward_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.HasKey("user_id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("CompanyManagement.Models.Ward", b =>
                {
                    b.Property<string>("ward_id")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("district_id")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("ward_name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ward_id");

                    b.ToTable("ward");
                });
#pragma warning restore 612, 618
        }
    }
}