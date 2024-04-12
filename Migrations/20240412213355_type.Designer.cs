﻿// <auto-generated />
using DataDataContext.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Technical_test_Backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240412213355_type")]
    partial class type
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ModelsContacts.Contacs.Contact", b =>
                {
                    b.Property<int>("Id_Contact")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdditionalField1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AdditionalField2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id_Contact");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ModelsUsers.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
