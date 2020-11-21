﻿// <auto-generated />
using System;
using CodersAcademy.API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodersAcademy.API.Migrations
{
    [DbContext(typeof(MusicContext))]
    partial class MusicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CodersAcademy.API.Model.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Backdrop")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Band")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Albuns");
                });

            modelBuilder.Entity("CodersAcademy.API.Model.Music", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Music");
                });

            modelBuilder.Entity("CodersAcademy.API.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("Password")
                        .HasMaxLength(200)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CodersAcademy.API.Model.UserFavoriteMusic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MusicId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MusicId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("UserFavoriteMusic");
                });

            modelBuilder.Entity("CodersAcademy.API.Model.Music", b =>
                {
                    b.HasOne("CodersAcademy.API.Model.Album", "Album")
                        .WithMany("Musics")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Album");
                });

            modelBuilder.Entity("CodersAcademy.API.Model.UserFavoriteMusic", b =>
                {
                    b.HasOne("CodersAcademy.API.Model.Music", "Music")
                        .WithOne()
                        .HasForeignKey("CodersAcademy.API.Model.UserFavoriteMusic", "MusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodersAcademy.API.Model.User", "User")
                        .WithMany("FavoriteMusics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Music");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CodersAcademy.API.Model.Album", b =>
                {
                    b.Navigation("Musics");
                });

            modelBuilder.Entity("CodersAcademy.API.Model.User", b =>
                {
                    b.Navigation("FavoriteMusics");
                });
#pragma warning restore 612, 618
        }
    }
}
