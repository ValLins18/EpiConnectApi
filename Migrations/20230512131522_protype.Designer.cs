﻿// <auto-generated />
using System;
using EpiConnectAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EpiConnectAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230512131522_protype")]
    partial class protype
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AddressId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("City");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Neighborhood");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Number");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("State");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Street");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Alert", b =>
                {
                    b.Property<int>("AlertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AlertId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlertId"));

                    b.Property<DateTime>("AlertDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("AlertDate");

                    b.Property<int>("DangerousLevel")
                        .HasColumnType("int")
                        .HasColumnName("DangerousLevel");

                    b.Property<int>("EpiId")
                        .HasColumnType("int")
                        .HasColumnName("EpiId");

                    b.Property<int>("MetricsId")
                        .HasColumnType("int")
                        .HasColumnName("MetricsId");

                    b.HasKey("AlertId");

                    b.HasIndex("EpiId");

                    b.HasIndex("MetricsId");

                    b.ToTable("Alert", (string)null);
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DepartmentId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Epi", b =>
                {
                    b.Property<int>("EpiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EpiId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EpiId"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ExpiryDate");

                    b.Property<DateTime>("ManufacturingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ManufacturingDate");

                    b.Property<int?>("MetricsId")
                        .HasColumnType("int")
                        .HasColumnName("MetricsId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("ProtectionType")
                        .HasColumnType("int")
                        .HasColumnName("ProtectionTypeId");

                    b.HasKey("EpiId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("MetricsId");

                    b.ToTable("Epi", "dbo");
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Metrics", b =>
                {
                    b.Property<int>("MetricsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MetricsId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MetricsId"));

                    b.Property<int>("BatteryLevel")
                        .HasColumnType("int")
                        .HasColumnName("BatteryLevel");

                    b.Property<bool>("IsContingency")
                        .HasColumnType("bit")
                        .HasColumnName("IsContingency");

                    b.Property<bool>("IsProtected")
                        .HasColumnType("bit")
                        .HasColumnName("IsProtected");

                    b.Property<int?>("Noise")
                        .HasColumnType("int")
                        .HasColumnName("Noise");

                    b.HasKey("MetricsId");

                    b.ToTable("Metrics", (string)null);
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PersonId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("AddressId");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("Document");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Email");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("Gender");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImgPath");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("Name");

                    b.Property<int>("PhoneId")
                        .HasColumnType("int")
                        .HasColumnName("PhoneId");

                    b.HasKey("PersonId");

                    b.HasIndex("AddressId");

                    b.HasIndex("PhoneId");

                    b.ToTable("Person", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Phone", b =>
                {
                    b.Property<int>("PhoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PhoneId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneId"));

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DDD");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("PhoneId");

                    b.ToTable("Phone", "dbo");
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PostId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("Salary");

                    b.HasKey("PostId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Warning", b =>
                {
                    b.Property<int>("WarningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("WarningId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarningId"));

                    b.Property<int>("AlertId")
                        .HasColumnType("int")
                        .HasColumnName("AlertId");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    b.Property<DateTime>("WarningDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("WarningDate");

                    b.HasKey("WarningId");

                    b.HasIndex("AlertId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Warning", (string)null);
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Employee", b =>
                {
                    b.HasBaseType("EpiConnectAPI.Core.Model.Person");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EntryDate");

                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("PostId");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Alert", b =>
                {
                    b.HasOne("EpiConnectAPI.Core.Model.Epi", "Epi")
                        .WithMany("Alerts")
                        .HasForeignKey("EpiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EpiConnectAPI.Core.Model.Metrics", "Metrics")
                        .WithMany()
                        .HasForeignKey("MetricsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Epi");

                    b.Navigation("Metrics");
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Epi", b =>
                {
                    b.HasOne("EpiConnectAPI.Core.Model.Employee", "Employee")
                        .WithMany("Epis")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("EpiConnectAPI.Core.Model.Metrics", "Metrics")
                        .WithMany()
                        .HasForeignKey("MetricsId");

                    b.Navigation("Employee");

                    b.Navigation("Metrics");
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Person", b =>
                {
                    b.HasOne("EpiConnectAPI.Core.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EpiConnectAPI.Core.Model.Phone", "Phone")
                        .WithMany()
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Post", b =>
                {
                    b.HasOne("EpiConnectAPI.Core.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Warning", b =>
                {
                    b.HasOne("EpiConnectAPI.Core.Model.Alert", "Alert")
                        .WithMany()
                        .HasForeignKey("AlertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EpiConnectAPI.Core.Model.Employee", "Employee")
                        .WithMany("Warnings")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alert");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Employee", b =>
                {
                    b.HasOne("EpiConnectAPI.Core.Model.Person", null)
                        .WithOne()
                        .HasForeignKey("EpiConnectAPI.Core.Model.Employee", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EpiConnectAPI.Core.Model.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EpiConnectAPI.Core.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Epi", b =>
                {
                    b.Navigation("Alerts");
                });

            modelBuilder.Entity("EpiConnectAPI.Core.Model.Employee", b =>
                {
                    b.Navigation("Epis");

                    b.Navigation("Warnings");
                });
#pragma warning restore 612, 618
        }
    }
}
