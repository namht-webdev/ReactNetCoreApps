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
    [Migration("20230713083808_update_requirement_model")]
    partial class update_requirement_model
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ward_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("address_id");

                    b.HasIndex("ward_id")
                        .IsUnique();

                    b.ToTable("addresse");
                });

            modelBuilder.Entity("CompanyManagement.Models.Announcement", b =>
                {
                    b.Property<string>("annc_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("date")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("department_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("annc_id");

                    b.HasIndex("department_id");

                    b.HasIndex("user_id");

                    b.ToTable("announcement");
                });

            modelBuilder.Entity("CompanyManagement.Models.Department", b =>
                {
                    b.Property<string>("department_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("department_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("floor")
                        .HasColumnType("tinyint");

                    b.HasKey("department_id");

                    b.ToTable("department");
                });

            modelBuilder.Entity("CompanyManagement.Models.District", b =>
                {
                    b.Property<string>("district_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("district_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("district_name2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("province_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("district_id");

                    b.HasIndex("province_id");

                    b.ToTable("district");
                });

            modelBuilder.Entity("CompanyManagement.Models.FingerPrinting", b =>
                {
                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("date")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("comein_time")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("comeout_time")
                        .HasColumnType("smalldatetime");

                    b.HasKey("user_id", "date");

                    b.ToTable("fingerprinting");
                });

            modelBuilder.Entity("CompanyManagement.Models.Level", b =>
                {
                    b.Property<string>("level_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("level_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("level_id");

                    b.ToTable("level");
                });

            modelBuilder.Entity("CompanyManagement.Models.Province", b =>
                {
                    b.Property<string>("province_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("postal_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("province_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("province_name2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("province_id");

                    b.ToTable("province");
                });

            modelBuilder.Entity("CompanyManagement.Models.Requirement", b =>
                {
                    b.Property<string>("requirement_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("date")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("from_user")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("request_message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("to_user")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("requirement_id");

                    b.HasIndex("from_user");

                    b.HasIndex("to_user");

                    b.ToTable("requirement");
                });

            modelBuilder.Entity("CompanyManagement.Models.Role", b =>
                {
                    b.Property<string>("role_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("role_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("role_id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("CompanyManagement.Models.Schedule", b =>
                {
                    b.Property<string>("schedule_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("date")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("time_end")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("time_start")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("schedule_id");

                    b.HasIndex("user_id");

                    b.ToTable("schedule");
                });

            modelBuilder.Entity("CompanyManagement.Models.User", b =>
                {
                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("birth_date")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("date_end")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("date_start")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("department_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("bit");

                    b.Property<string>("level_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password_hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("salary")
                        .HasColumnType("float");

                    b.HasKey("user_id");

                    b.HasIndex("address_id");

                    b.HasIndex("department_id")
                        .IsUnique();

                    b.HasIndex("level_id")
                        .IsUnique();

                    b.HasIndex("role_id")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("CompanyManagement.Models.Ward", b =>
                {
                    b.Property<string>("ward_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("district_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ward_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ward_name2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ward_id");

                    b.HasIndex("district_id");

                    b.ToTable("ward");
                });

            modelBuilder.Entity("CompanyManagement.Models.Address", b =>
                {
                    b.HasOne("CompanyManagement.Models.Ward", "ward")
                        .WithOne("address")
                        .HasForeignKey("CompanyManagement.Models.Address", "ward_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ward");
                });

            modelBuilder.Entity("CompanyManagement.Models.Announcement", b =>
                {
                    b.HasOne("CompanyManagement.Models.Department", "department")
                        .WithMany("announcements")
                        .HasForeignKey("department_id");

                    b.HasOne("CompanyManagement.Models.User", "user")
                        .WithMany("announcements")
                        .HasForeignKey("user_id");

                    b.Navigation("department");

                    b.Navigation("user");
                });

            modelBuilder.Entity("CompanyManagement.Models.District", b =>
                {
                    b.HasOne("CompanyManagement.Models.Province", "province")
                        .WithMany("districts")
                        .HasForeignKey("province_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("province");
                });

            modelBuilder.Entity("CompanyManagement.Models.FingerPrinting", b =>
                {
                    b.HasOne("CompanyManagement.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("CompanyManagement.Models.Requirement", b =>
                {
                    b.HasOne("CompanyManagement.Models.User", "sender")
                        .WithMany()
                        .HasForeignKey("from_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanyManagement.Models.User", "reciever")
                        .WithMany()
                        .HasForeignKey("to_user");

                    b.Navigation("reciever");

                    b.Navigation("sender");
                });

            modelBuilder.Entity("CompanyManagement.Models.Schedule", b =>
                {
                    b.HasOne("CompanyManagement.Models.User", "user")
                        .WithMany("schedules")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("CompanyManagement.Models.User", b =>
                {
                    b.HasOne("CompanyManagement.Models.Address", "address")
                        .WithMany()
                        .HasForeignKey("address_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanyManagement.Models.Department", "department")
                        .WithOne("user")
                        .HasForeignKey("CompanyManagement.Models.User", "department_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanyManagement.Models.Level", "level")
                        .WithOne("user")
                        .HasForeignKey("CompanyManagement.Models.User", "level_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanyManagement.Models.Role", "role")
                        .WithOne("user")
                        .HasForeignKey("CompanyManagement.Models.User", "role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("address");

                    b.Navigation("department");

                    b.Navigation("level");

                    b.Navigation("role");
                });

            modelBuilder.Entity("CompanyManagement.Models.Ward", b =>
                {
                    b.HasOne("CompanyManagement.Models.District", "district")
                        .WithMany("wards")
                        .HasForeignKey("district_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("district");
                });

            modelBuilder.Entity("CompanyManagement.Models.Department", b =>
                {
                    b.Navigation("announcements");

                    b.Navigation("user");
                });

            modelBuilder.Entity("CompanyManagement.Models.District", b =>
                {
                    b.Navigation("wards");
                });

            modelBuilder.Entity("CompanyManagement.Models.Level", b =>
                {
                    b.Navigation("user");
                });

            modelBuilder.Entity("CompanyManagement.Models.Province", b =>
                {
                    b.Navigation("districts");
                });

            modelBuilder.Entity("CompanyManagement.Models.Role", b =>
                {
                    b.Navigation("user");
                });

            modelBuilder.Entity("CompanyManagement.Models.User", b =>
                {
                    b.Navigation("announcements");

                    b.Navigation("schedules");
                });

            modelBuilder.Entity("CompanyManagement.Models.Ward", b =>
                {
                    b.Navigation("address")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
