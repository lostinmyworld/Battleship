﻿// <auto-generated />
using System;
using Data.EfCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Web.Battleship.Migrations
{
    [DbContext(typeof(BattleShipContext))]
    [Migration("20210204110953_SessionChanges")]
    partial class SessionChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Data.EfCore.Models.BattleSession", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<int?>("Player1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Player2Id")
                        .HasColumnType("int");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Data.EfCore.Models.Battleship", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("GridId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDestroyed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHit")
                        .HasColumnType("bit");

                    b.Property<int>("MaxX")
                        .HasColumnType("int");

                    b.Property<int>("MaxY")
                        .HasColumnType("int");

                    b.Property<int>("MinX")
                        .HasColumnType("int");

                    b.Property<int>("MinY")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GridId");

                    b.ToTable("Battleships");
                });

            modelBuilder.Entity("Data.EfCore.Models.CannonBall", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("GridId")
                        .HasColumnType("int");

                    b.Property<bool>("Hit")
                        .HasColumnType("bit");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GridId");

                    b.ToTable("CannonBalls");
                });

            modelBuilder.Entity("Data.EfCore.Models.Grid", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("DimensionX")
                        .HasColumnType("int");

                    b.Property<int>("DimensionY")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Grids");
                });

            modelBuilder.Entity("Data.EfCore.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("GridId")
                        .HasColumnType("int");

                    b.Property<bool>("IsWinner")
                        .HasColumnType("bit");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GridId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Data.EfCore.Models.BattleSession", b =>
                {
                    b.HasOne("Data.EfCore.Models.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1Id");

                    b.HasOne("Data.EfCore.Models.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id");

                    b.Navigation("Player1");

                    b.Navigation("Player2");
                });

            modelBuilder.Entity("Data.EfCore.Models.Battleship", b =>
                {
                    b.HasOne("Data.EfCore.Models.Grid", "Grid")
                        .WithMany("Ships")
                        .HasForeignKey("GridId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grid");
                });

            modelBuilder.Entity("Data.EfCore.Models.CannonBall", b =>
                {
                    b.HasOne("Data.EfCore.Models.Grid", "Grid")
                        .WithMany("CannonBallsShot")
                        .HasForeignKey("GridId");

                    b.Navigation("Grid");
                });

            modelBuilder.Entity("Data.EfCore.Models.Player", b =>
                {
                    b.HasOne("Data.EfCore.Models.Grid", "Grid")
                        .WithMany()
                        .HasForeignKey("GridId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grid");
                });

            modelBuilder.Entity("Data.EfCore.Models.Grid", b =>
                {
                    b.Navigation("CannonBallsShot");

                    b.Navigation("Ships");
                });
#pragma warning restore 612, 618
        }
    }
}