﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(CompanyManagementDbContext))]
    partial class CompanyManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("CompanyManagement.Models.District", b =>
                {
                    b.HasOne("CompanyManagement.Models.Province", "province")
                        .WithMany("districts")
                        .HasForeignKey("province_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("province");
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

            modelBuilder.Entity("CompanyManagement.Models.District", b =>
                {
                    b.Navigation("wards");
                });

            modelBuilder.Entity("CompanyManagement.Models.Province", b =>
                {
                    b.Navigation("districts");
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
