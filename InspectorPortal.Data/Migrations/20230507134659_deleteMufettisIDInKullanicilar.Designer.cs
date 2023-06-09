﻿// <auto-generated />
using System;
using InspectorPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InspectorPortal.Data.Migrations
{
    [DbContext(typeof(InspectorPortalDbContext))]
    [Migration("20230507134659_deleteMufettisIDInKullanicilar")]
    partial class deleteMufettisIDInKullanicilar
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InspectorPortal.Data.Entities.DisiplinCezasi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BaskanlikOneri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisiplinKuruluOneri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GorevID")
                        .HasColumnType("int");

                    b.Property<string>("MufettisOneri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Onaylanan")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GorevID");

                    b.ToTable("DisiplinCezalari");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.Gorev", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BaslamaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BitisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<int>("GorevTipi")
                        .HasColumnType("int");

                    b.Property<string>("Konusu")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UnitID")
                        .HasColumnType("int");

                    b.Property<DateTime>("VerilisTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UnitID");

                    b.ToTable("Gorevler");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.HukukiIslem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BaskanlikOneri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GorevID")
                        .HasColumnType("int");

                    b.Property<string>("MufettisOneri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Onaylanan")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GorevID");

                    b.ToTable("HukukiIslemler");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.IdariTedbir", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BaskanlikOneri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GorevID")
                        .HasColumnType("int");

                    b.Property<string>("MufettisOneri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Onaylanan")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GorevID");

                    b.ToTable("IdariTedbirler");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parola")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyisim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unvan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.Mufettis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CalismaDurumu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("KurumSicilNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MufettisNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Soyisim")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Unvan")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Mufettisler");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.MufettisGorev", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GorevID")
                        .HasColumnType("int");

                    b.Property<int>("MufettisID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GorevID");

                    b.HasIndex("MufettisID");

                    b.ToTable("MufettisGorevleri");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.UniteBirim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Birim")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("BirimID")
                        .HasColumnType("int");

                    b.Property<string>("BirimSorumlusu")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BirimID");

                    b.ToTable("UniteBirimler");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.DisiplinCezasi", b =>
                {
                    b.HasOne("InspectorPortal.Data.Entities.Gorev", "Gorev")
                        .WithMany("DisiplinCezalari")
                        .HasForeignKey("GorevID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gorev");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.Gorev", b =>
                {
                    b.HasOne("InspectorPortal.Data.Entities.UniteBirim", "UniteBirim")
                        .WithMany()
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UniteBirim");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.HukukiIslem", b =>
                {
                    b.HasOne("InspectorPortal.Data.Entities.Gorev", "Gorev")
                        .WithMany("HukukiIslemler")
                        .HasForeignKey("GorevID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gorev");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.IdariTedbir", b =>
                {
                    b.HasOne("InspectorPortal.Data.Entities.Gorev", "Gorev")
                        .WithMany("IdariTedbirler")
                        .HasForeignKey("GorevID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gorev");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.MufettisGorev", b =>
                {
                    b.HasOne("InspectorPortal.Data.Entities.Gorev", "Gorev")
                        .WithMany()
                        .HasForeignKey("GorevID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InspectorPortal.Data.Entities.Mufettis", "Mufettis")
                        .WithMany()
                        .HasForeignKey("MufettisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gorev");

                    b.Navigation("Mufettis");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.UniteBirim", b =>
                {
                    b.HasOne("InspectorPortal.Data.Entities.UniteBirim", "UstBirim")
                        .WithMany()
                        .HasForeignKey("BirimID");

                    b.Navigation("UstBirim");
                });

            modelBuilder.Entity("InspectorPortal.Data.Entities.Gorev", b =>
                {
                    b.Navigation("DisiplinCezalari");

                    b.Navigation("HukukiIslemler");

                    b.Navigation("IdariTedbirler");
                });
#pragma warning restore 612, 618
        }
    }
}
