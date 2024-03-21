﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemBibliotecario.Data;

#nullable disable

namespace SistemBibliotecario.Migrations
{
    [DbContext(typeof(bibliotecaDBContext))]
    partial class bibliotecaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemBibliotecario.Models.autorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("dataNascimento")
                        .HasMaxLength(255)
                        .HasColumnType("date");

                    b.Property<string>("nacionalidade")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("SistemBibliotecario.Models.avaliacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("comentario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateOnly>("dataAvaliacao")
                        .HasMaxLength(255)
                        .HasColumnType("date");

                    b.Property<int>("livroId")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("pontuacao")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("usuarioId")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("livroId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("SistemBibliotecario.Models.editoraModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("anoFundacao")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<string>("localizacao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Editores");
                });

            modelBuilder.Entity("SistemBibliotecario.Models.emprestimoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("dataDevolucao")
                        .HasMaxLength(255)
                        .HasColumnType("date");

                    b.Property<DateOnly>("dataEmprestimo")
                        .HasMaxLength(255)
                        .HasColumnType("date");

                    b.Property<int>("livroId")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("usuarioId")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("livroId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("SistemBibliotecario.Models.livroModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ISBN")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("anoPublicacao")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int?>("editoraModelId")
                        .HasColumnType("int");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sinopse")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("editoraModelId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("SistemBibliotecario.Models.reservaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("dataReserva")
                        .HasMaxLength(255)
                        .HasColumnType("date");

                    b.Property<int>("livroId")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("usuarioId")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("livroId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("SistemBibliotecario.Models.usuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemBibliotecario.Models.avaliacaoModel", b =>
                {
                    b.HasOne("SistemBibliotecario.Models.livroModel", "livro")
                        .WithMany()
                        .HasForeignKey("livroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemBibliotecario.Models.usuarioModel", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("livro");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("SistemBibliotecario.Models.emprestimoModel", b =>
                {
                    b.HasOne("SistemBibliotecario.Models.livroModel", "livro")
                        .WithMany()
                        .HasForeignKey("livroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemBibliotecario.Models.usuarioModel", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("livro");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("SistemBibliotecario.Models.livroModel", b =>
                {
                    b.HasOne("SistemBibliotecario.Models.editoraModel", null)
                        .WithMany("livros")
                        .HasForeignKey("editoraModelId");
                });

            modelBuilder.Entity("SistemBibliotecario.Models.reservaModel", b =>
                {
                    b.HasOne("SistemBibliotecario.Models.livroModel", "livro")
                        .WithMany()
                        .HasForeignKey("livroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemBibliotecario.Models.usuarioModel", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("livro");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("SistemBibliotecario.Models.editoraModel", b =>
                {
                    b.Navigation("livros");
                });
#pragma warning restore 612, 618
        }
    }
}
