﻿// <auto-generated />
using EFSQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFSQLite.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("EFSQLite.Models.ObjectModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PreviewImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("TagName")
                        .HasColumnType("TEXT");

                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("ObjectModels");
                });

            modelBuilder.Entity("EFSQLite.Models.ObjectTypeModel", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PreviewImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("TagName")
                        .HasColumnType("TEXT");

                    b.HasKey("TypeId");

                    b.ToTable("ObjectTypeModels");
                });

            modelBuilder.Entity("EFSQLite.Models.ObjectModel", b =>
                {
                    b.HasOne("EFSQLite.Models.ObjectTypeModel", "TypeModel")
                        .WithMany("Objects")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
