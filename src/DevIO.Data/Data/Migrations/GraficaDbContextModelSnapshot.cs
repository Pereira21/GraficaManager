﻿// <auto-generated />
using System;
using DevIO.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevIO.Data.Migrations
{
    [DbContext(typeof(GraficaDbContext))]
    partial class GraficaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevIO.Business.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailContato")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TelefoneContato")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoPessoa")
                        .HasColumnType("int");

                    b.Property<DateTime>("_Insert")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("DevIO.Business.Models.CompraMateriaPrima", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MateriaPrimaEstoqueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("_Insert")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MateriaPrimaEstoqueId");

                    b.ToTable("CompraMateriaPrima");
                });

            modelBuilder.Entity("DevIO.Business.Models.MateriaPrimaEstoque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Imagem")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<DateTime>("_Insert")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MateriaPrimaEstoque");
                });

            modelBuilder.Entity("DevIO.Business.Models.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NumeroPedido")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("_Insert")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("DevIO.Business.Models.PedidoMateriaPrimaEstoque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MateriaPrimaEstoqueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<DateTime>("_Insert")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MateriaPrimaEstoqueId");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidoMateriaPrimaEstoque");
                });

            modelBuilder.Entity("DevIO.Business.Models.CompraMateriaPrima", b =>
                {
                    b.HasOne("DevIO.Business.Models.MateriaPrimaEstoque", "MateriaPrimaEstoque")
                        .WithMany("Compras")
                        .HasForeignKey("MateriaPrimaEstoqueId")
                        .IsRequired();
                });

            modelBuilder.Entity("DevIO.Business.Models.Pedido", b =>
                {
                    b.HasOne("DevIO.Business.Models.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .IsRequired();
                });

            modelBuilder.Entity("DevIO.Business.Models.PedidoMateriaPrimaEstoque", b =>
                {
                    b.HasOne("DevIO.Business.Models.MateriaPrimaEstoque", "MateriaPrimaEstoque")
                        .WithMany("Pedidos")
                        .HasForeignKey("MateriaPrimaEstoqueId")
                        .IsRequired();

                    b.HasOne("DevIO.Business.Models.Pedido", "Pedido")
                        .WithMany("MateriasPrimas")
                        .HasForeignKey("PedidoId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
