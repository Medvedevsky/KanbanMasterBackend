﻿// <auto-generated />
using System;
using KanbanMaster.DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KanbanMaster.DataLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230110221328_InitalScheme")]
    partial class InitalScheme
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.CardFile", b =>
                {
                    b.Property<int>("CardFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardFileId"));

                    b.Property<int>("KanbanCardId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardFileId");

                    b.HasIndex("KanbanCardId");

                    b.ToTable("CardFile");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.KanbanBoard", b =>
                {
                    b.Property<int>("KanbanBoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KanbanBoardId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KanbanBoardId");

                    b.ToTable("KanbanBoard");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.KanbanCard", b =>
                {
                    b.Property<int>("KanbanCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KanbanCardId"));

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KanbanColumnId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KanbanCardId");

                    b.HasIndex("KanbanColumnId");

                    b.ToTable("KanbanCard");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.KanbanColumn", b =>
                {
                    b.Property<int>("KanbanColumnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KanbanColumnId"));

                    b.Property<int>("KanbanBoardId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KanbanColumnId");

                    b.HasIndex("KanbanBoardId");

                    b.ToTable("KanbanColumn");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.KanbanUser", b =>
                {
                    b.Property<int>("KanbanUserId")
                        .HasColumnType("int");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserForeignKeyId")
                        .HasColumnType("int");

                    b.HasKey("KanbanUserId");

                    b.HasIndex("UserForeignKeyId")
                        .IsUnique();

                    b.ToTable("KanbanUser");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.CardFile", b =>
                {
                    b.HasOne("KanbanMaster.DataLayer.Data.Models.KanbanCard", "KanbanCard")
                        .WithMany("CardFiles")
                        .HasForeignKey("KanbanCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KanbanCard");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.KanbanCard", b =>
                {
                    b.HasOne("KanbanMaster.DataLayer.Data.Models.KanbanColumn", "KanbanColumn")
                        .WithMany("KanbanCards")
                        .HasForeignKey("KanbanColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KanbanColumn");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.KanbanColumn", b =>
                {
                    b.HasOne("KanbanMaster.DataLayer.Data.Models.KanbanBoard", "KanbanBoard")
                        .WithMany("KanbanColumns")
                        .HasForeignKey("KanbanBoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KanbanBoard");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.KanbanUser", b =>
                {
                    b.HasOne("KanbanMaster.DataLayer.Data.Models.User", "User")
                        .WithOne("KanbanUser")
                        .HasForeignKey("KanbanMaster.DataLayer.Data.Models.KanbanUser", "UserForeignKeyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.User", b =>
                {
                    b.HasOne("KanbanMaster.DataLayer.Data.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.KanbanBoard", b =>
                {
                    b.Navigation("KanbanColumns");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.KanbanCard", b =>
                {
                    b.Navigation("CardFiles");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.KanbanColumn", b =>
                {
                    b.Navigation("KanbanCards");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("KanbanMaster.DataLayer.Data.Models.User", b =>
                {
                    b.Navigation("KanbanUser")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
