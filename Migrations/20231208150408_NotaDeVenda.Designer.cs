﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using micherlane.Models;

#nullable disable

namespace micherlane.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231208150408_NotaDeVenda")]
    partial class NotaDeVenda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("micherlane.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("micherlane.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Percentual")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("micherlane.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("micherlane.Models.NotaDaVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<bool?>("Devolvido")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Tipo")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("TipoDePagamentoId")
                        .HasColumnType("int");

                    b.Property<int>("VendedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoDePagamentoId");

                    b.HasIndex("VendedorId");

                    b.ToTable("NotaDaVenda");
                });

            modelBuilder.Entity("micherlane.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataLimite")
                        .HasColumnType("date");

                    b.Property<int>("NotaDaVendaId")
                        .HasColumnType("int");

                    b.Property<bool>("Pago")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("NotaDaVendaId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("micherlane.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("micherlane.Models.TipoDePagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("InformacoesAdicionais")
                        .HasColumnType("longtext");

                    b.Property<string>("NomeDoCobrado")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TipoDePagamento");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TipoDePagamento");
                });

            modelBuilder.Entity("micherlane.Models.Transportadora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Transportadora");
                });

            modelBuilder.Entity("micherlane.Models.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("NotaDaVendaTransportadora", b =>
                {
                    b.Property<int>("NotaDaVendasId")
                        .HasColumnType("int");

                    b.Property<int>("TransportadorasId")
                        .HasColumnType("int");

                    b.HasKey("NotaDaVendasId", "TransportadorasId");

                    b.HasIndex("TransportadorasId");

                    b.ToTable("NotaDaVendaTransportadora");
                });

            modelBuilder.Entity("micherlane.Models.PagamentoComCartao", b =>
                {
                    b.HasBaseType("micherlane.Models.TipoDePagamento");

                    b.Property<string>("Bandeira")
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroDoCartao")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("PagamentoComCartao");
                });

            modelBuilder.Entity("micherlane.Models.PagamentoComCheque", b =>
                {
                    b.HasBaseType("micherlane.Models.TipoDePagamento");

                    b.Property<int>("Banco")
                        .HasColumnType("int");

                    b.Property<string>("NomeDoBanco")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("PagamentoComCheque");
                });

            modelBuilder.Entity("micherlane.Models.Item", b =>
                {
                    b.HasOne("micherlane.Models.Produto", "Produto")
                        .WithMany("Items")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("micherlane.Models.NotaDaVenda", b =>
                {
                    b.HasOne("micherlane.Models.Cliente", "Cliente")
                        .WithMany("NotaDaVendas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("micherlane.Models.TipoDePagamento", "TipoDePagamento")
                        .WithMany("NotaDaVendas")
                        .HasForeignKey("TipoDePagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("micherlane.Models.Vendedor", "Vendedor")
                        .WithMany("NotaDeVendas")
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("TipoDePagamento");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("micherlane.Models.Pagamento", b =>
                {
                    b.HasOne("micherlane.Models.NotaDaVenda", "NotaDaVenda")
                        .WithMany("Pagamentos")
                        .HasForeignKey("NotaDaVendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotaDaVenda");
                });

            modelBuilder.Entity("micherlane.Models.Produto", b =>
                {
                    b.HasOne("micherlane.Models.Marca", "Marca")
                        .WithMany("Produtos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("NotaDaVendaTransportadora", b =>
                {
                    b.HasOne("micherlane.Models.NotaDaVenda", null)
                        .WithMany()
                        .HasForeignKey("NotaDaVendasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("micherlane.Models.Transportadora", null)
                        .WithMany()
                        .HasForeignKey("TransportadorasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("micherlane.Models.Cliente", b =>
                {
                    b.Navigation("NotaDaVendas");
                });

            modelBuilder.Entity("micherlane.Models.Marca", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("micherlane.Models.NotaDaVenda", b =>
                {
                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("micherlane.Models.Produto", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("micherlane.Models.TipoDePagamento", b =>
                {
                    b.Navigation("NotaDaVendas");
                });

            modelBuilder.Entity("micherlane.Models.Vendedor", b =>
                {
                    b.Navigation("NotaDeVendas");
                });
#pragma warning restore 612, 618
        }
    }
}
