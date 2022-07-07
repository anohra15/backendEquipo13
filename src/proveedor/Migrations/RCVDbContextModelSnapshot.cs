﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backendRCVUcab.Persistence.Database;

namespace RCVUcabBackend.Migrations
{
    [DbContext(typeof(RCVDbContext))]
    partial class RCVDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CotizacionEntityPiezaEntity", b =>
                {
                    b.Property<Guid>("cotizacionesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("piezasId")
                        .HasColumnType("uuid");

                    b.HasKey("cotizacionesId", "piezasId");

                    b.HasIndex("piezasId");

                    b.ToTable("CotizacionEntityPiezaEntity");
                });

            modelBuilder.Entity("MarcaEntityProveedorEntity", b =>
                {
                    b.Property<Guid>("marcasId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("proveedoresId")
                        .HasColumnType("uuid");

                    b.HasKey("marcasId", "proveedoresId");

                    b.HasIndex("proveedoresId");

                    b.ToTable("MarcaEntityProveedorEntity");
                });

            modelBuilder.Entity("OrdenDeCompraEntityPiezaEntity", b =>
                {
                    b.Property<Guid>("ordenesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("piezasId")
                        .HasColumnType("uuid");

                    b.HasKey("ordenesId", "piezasId");

                    b.HasIndex("piezasId");

                    b.ToTable("OrdenDeCompraEntityPiezaEntity");
                });

            modelBuilder.Entity("PiezaEntitySolicitudEntity", b =>
                {
                    b.Property<Guid>("piezasId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("solicitudesId")
                        .HasColumnType("uuid");

                    b.HasKey("piezasId", "solicitudesId");

                    b.HasIndex("solicitudesId");

                    b.ToTable("PiezaEntitySolicitudEntity");
                });

            modelBuilder.Entity("ProveedorEntitySolicitudEntity", b =>
                {
                    b.Property<Guid>("proveedoresId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("solicitudesId")
                        .HasColumnType("uuid");

                    b.HasKey("proveedoresId", "solicitudesId");

                    b.HasIndex("solicitudesId");

                    b.ToTable("ProveedorEntitySolicitudEntity");
                });

            modelBuilder.Entity("backendRCVUcab.Persistence.Entities.CotizacionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<double>("costo_total")
                        .HasColumnType("double precision");

                    b.Property<int>("tiempo_de_entrega")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Cotizacion");
                });

            modelBuilder.Entity("backendRCVUcab.Persistence.Entities.MarcaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("backendRCVUcab.Persistence.Entities.OrdenDeCompraEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<double>("costo_total")
                        .HasColumnType("double precision");

                    b.Property<int>("estado")
                        .HasColumnType("integer");

                    b.Property<DateTime>("fecha_vencimiento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("tiempo_de_entrega")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("OrdenDeCompra");
                });

            modelBuilder.Entity("backendRCVUcab.Persistence.Entities.PiezaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<double>("costo")
                        .HasMaxLength(100)
                        .HasColumnType("double precision");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("tipo")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Pieza");
                });

            modelBuilder.Entity("backendRCVUcab.Persistence.Entities.ProveedorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid?>("tipoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("tipoId");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("backendRCVUcab.Persistence.Entities.SolicitudEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<int>("estado")
                        .HasColumnType("integer");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Solicitud");
                });

            modelBuilder.Entity("backendRCVUcab.Persistence.Entities.Tipo_Proveedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("tipo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tipo_Proveedor");
                });

            modelBuilder.Entity("CotizacionEntityPiezaEntity", b =>
                {
                    b.HasOne("backendRCVUcab.Persistence.Entities.CotizacionEntity", null)
                        .WithMany()
                        .HasForeignKey("cotizacionesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backendRCVUcab.Persistence.Entities.PiezaEntity", null)
                        .WithMany()
                        .HasForeignKey("piezasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarcaEntityProveedorEntity", b =>
                {
                    b.HasOne("backendRCVUcab.Persistence.Entities.MarcaEntity", null)
                        .WithMany()
                        .HasForeignKey("marcasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backendRCVUcab.Persistence.Entities.ProveedorEntity", null)
                        .WithMany()
                        .HasForeignKey("proveedoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrdenDeCompraEntityPiezaEntity", b =>
                {
                    b.HasOne("backendRCVUcab.Persistence.Entities.OrdenDeCompraEntity", null)
                        .WithMany()
                        .HasForeignKey("ordenesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backendRCVUcab.Persistence.Entities.PiezaEntity", null)
                        .WithMany()
                        .HasForeignKey("piezasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PiezaEntitySolicitudEntity", b =>
                {
                    b.HasOne("backendRCVUcab.Persistence.Entities.PiezaEntity", null)
                        .WithMany()
                        .HasForeignKey("piezasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backendRCVUcab.Persistence.Entities.SolicitudEntity", null)
                        .WithMany()
                        .HasForeignKey("solicitudesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProveedorEntitySolicitudEntity", b =>
                {
                    b.HasOne("backendRCVUcab.Persistence.Entities.ProveedorEntity", null)
                        .WithMany()
                        .HasForeignKey("proveedoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backendRCVUcab.Persistence.Entities.SolicitudEntity", null)
                        .WithMany()
                        .HasForeignKey("solicitudesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backendRCVUcab.Persistence.Entities.ProveedorEntity", b =>
                {
                    b.HasOne("backendRCVUcab.Persistence.Entities.Tipo_Proveedor", "tipo")
                        .WithMany()
                        .HasForeignKey("tipoId");

                    b.Navigation("tipo");
                });
#pragma warning restore 612, 618
        }
    }
}
