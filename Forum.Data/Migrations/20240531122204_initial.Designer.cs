﻿// <auto-generated />
using System;
using Forum.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Forum.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240531122204_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Forum.Entities.ForumEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Forum");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 5, 31, 16, 22, 3, 870, DateTimeKind.Local).AddTicks(1483),
                            Description = " ტესტ საკითხი 111111111",
                            State = 0,
                            Status = 1,
                            Title = "ტესტი1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 5, 31, 16, 22, 3, 870, DateTimeKind.Local).AddTicks(1496),
                            Description = " ტესტ საკითხი 222222",
                            State = 0,
                            Status = 1,
                            Title = "ტესტი2"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 5, 31, 16, 22, 3, 870, DateTimeKind.Local).AddTicks(1497),
                            Description = " ტესტ საკითხი 333333",
                            State = 0,
                            Status = 1,
                            Title = "ტესტი2"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 5, 31, 16, 22, 3, 870, DateTimeKind.Local).AddTicks(1499),
                            Description = " ტესტ საკითხი 444444",
                            State = 0,
                            Status = 1,
                            Title = "ტესტი4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
