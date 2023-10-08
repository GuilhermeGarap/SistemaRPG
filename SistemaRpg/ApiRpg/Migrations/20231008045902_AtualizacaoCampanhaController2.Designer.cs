﻿// <auto-generated />
using System;
using ApiRpg.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiRpg.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20231008045902_AtualizacaoCampanhaController2")]
    partial class AtualizacaoCampanhaController2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("ApiRpg.Models.Campanha", b =>
                {
                    b.Property<int>("CampanhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sinopse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CampanhaId");

                    b.ToTable("Campanhas");
                });

            modelBuilder.Entity("ApiRpg.Models.Classe", b =>
                {
                    b.Property<int>("ClasseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AtributoBonus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClasseId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("ApiRpg.Models.Ficha", b =>
                {
                    b.Property<int>("FichaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Agilidade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CampanhaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClasseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DesAparencia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Estamina")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Forca")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Historia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Presenca")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sabedoria")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Vida")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Vigor")
                        .HasColumnType("INTEGER");

                    b.HasKey("FichaId");

                    b.HasIndex("CampanhaId");

                    b.HasIndex("ClasseId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Fichas");
                });

            modelBuilder.Entity("ApiRpg.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ApiRpg.Models.Ficha", b =>
                {
                    b.HasOne("ApiRpg.Models.Campanha", "Campanha")
                        .WithMany("Fichas")
                        .HasForeignKey("CampanhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiRpg.Models.Classe", "Classe")
                        .WithMany()
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiRpg.Models.Usuario", "Usuario")
                        .WithMany("Fichas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Campanha");

                    b.Navigation("Classe");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApiRpg.Models.Campanha", b =>
                {
                    b.Navigation("Fichas");
                });

            modelBuilder.Entity("ApiRpg.Models.Usuario", b =>
                {
                    b.Navigation("Fichas");
                });
#pragma warning restore 612, 618
        }
    }
}
