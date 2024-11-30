﻿// <auto-generated />
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20241130220625_FirstMigrations")]
    partial class FirstMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("API.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            ClienteId = 1,
                            Cpf = "1234",
                            CriadoEm = new DateTime(2024, 12, 7, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9877),
                            Nome = "Luis",
                            Telefone = "41984707329"
                        },
                        new
                        {
                            ClienteId = 2,
                            Cpf = "5678",
                            CriadoEm = new DateTime(2024, 12, 8, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9882),
                            Nome = "Victor",
                            Telefone = "41997438180"
                        },
                        new
                        {
                            ClienteId = 3,
                            Cpf = "9101",
                            CriadoEm = new DateTime(2024, 12, 8, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9885),
                            Nome = "Carmem",
                            Telefone = "41963457075"
                        },
                        new
                        {
                            ClienteId = 4,
                            Cpf = "1121",
                            CriadoEm = new DateTime(2024, 12, 8, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9888),
                            Nome = "Otavio",
                            Telefone = "41988623514"
                        },
                        new
                        {
                            ClienteId = 5,
                            Cpf = "3141",
                            CriadoEm = new DateTime(2024, 12, 9, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9890),
                            Nome = "João Pedro",
                            Telefone = "41999125678"
                        },
                        new
                        {
                            ClienteId = 6,
                            Cpf = "5161",
                            CriadoEm = new DateTime(2024, 12, 9, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9893),
                            Nome = "Luisa",
                            Telefone = "43990842030"
                        },
                        new
                        {
                            ClienteId = 7,
                            Cpf = "7181",
                            CriadoEm = new DateTime(2024, 12, 10, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9895),
                            Nome = "Vitória",
                            Telefone = "47988702098"
                        },
                        new
                        {
                            ClienteId = 8,
                            Cpf = "9202",
                            CriadoEm = new DateTime(2024, 12, 10, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9898),
                            Nome = "Julia",
                            Telefone = "42988635587"
                        },
                        new
                        {
                            ClienteId = 9,
                            Cpf = "1222",
                            CriadoEm = new DateTime(2024, 12, 12, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9901),
                            Nome = "Marcela",
                            Telefone = "41995234578"
                        },
                        new
                        {
                            ClienteId = 10,
                            Cpf = "3242",
                            CriadoEm = new DateTime(2024, 12, 12, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9904),
                            Nome = "Marcia",
                            Telefone = "45987889339"
                        });
                });

            modelBuilder.Entity("API.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cargo")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("NRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionarios");

                    b.HasData(
                        new
                        {
                            FuncionarioId = 1,
                            Cargo = "Luthier",
                            CriadoEm = new DateTime(2024, 12, 2, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9688),
                            Nome = "Cleiton"
                        },
                        new
                        {
                            FuncionarioId = 2,
                            Cargo = "Luthier Aprendiz",
                            CriadoEm = new DateTime(2025, 2, 1, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9701),
                            Nome = "Antônio"
                        },
                        new
                        {
                            FuncionarioId = 3,
                            Cargo = "Luthier",
                            CriadoEm = new DateTime(2025, 2, 15, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9704),
                            Nome = "Paulo"
                        });
                });

            modelBuilder.Entity("API.Models.OrdemDeServico", b =>
                {
                    b.Property<int>("OrdemDeServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("DescricaoServico")
                        .HasColumnType("TEXT");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Instrumento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<double>("ValorEstimado")
                        .HasColumnType("REAL");

                    b.HasKey("OrdemDeServicoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("OrdensServicos");

                    b.HasData(
                        new
                        {
                            OrdemDeServicoId = 1,
                            ClienteId = 1,
                            CriadoEm = new DateTime(2024, 12, 7, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(14),
                            DescricaoServico = "Troca da Cortiça",
                            FuncionarioId = 1,
                            Instrumento = "Clarinete",
                            Status = "Finalizado",
                            ValorEstimado = 106.59999999999999
                        },
                        new
                        {
                            OrdemDeServicoId = 2,
                            ClienteId = 2,
                            CriadoEm = new DateTime(2024, 12, 8, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(18),
                            DescricaoServico = "Realinhamento do Braço",
                            FuncionarioId = 2,
                            Instrumento = "Violão Takamine",
                            Status = "Pendente",
                            ValorEstimado = 560.0
                        },
                        new
                        {
                            OrdemDeServicoId = 3,
                            ClienteId = 3,
                            CriadoEm = new DateTime(2024, 12, 8, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(21),
                            DescricaoServico = "Lustragem",
                            FuncionarioId = 1,
                            Instrumento = "Trombone",
                            Status = "Pendente",
                            ValorEstimado = 130.0
                        },
                        new
                        {
                            OrdemDeServicoId = 4,
                            ClienteId = 6,
                            CriadoEm = new DateTime(2024, 12, 9, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(25),
                            DescricaoServico = "Troca de cordas e Manutenções Gerais",
                            FuncionarioId = 1,
                            Instrumento = "Ibanez",
                            Status = "Em Andamento",
                            ValorEstimado = 570.0
                        },
                        new
                        {
                            OrdemDeServicoId = 5,
                            ClienteId = 4,
                            CriadoEm = new DateTime(2024, 12, 8, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(28),
                            DescricaoServico = "Revisão",
                            FuncionarioId = 2,
                            Instrumento = "Fagote",
                            Status = "Pendente",
                            ValorEstimado = 200.0
                        },
                        new
                        {
                            OrdemDeServicoId = 6,
                            ClienteId = 8,
                            CriadoEm = new DateTime(2024, 12, 10, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(31),
                            DescricaoServico = "Realinhamento do Braço",
                            FuncionarioId = 2,
                            Instrumento = "Takamine",
                            Status = "Pendente",
                            ValorEstimado = 500.0
                        },
                        new
                        {
                            OrdemDeServicoId = 7,
                            ClienteId = 3,
                            CriadoEm = new DateTime(2024, 12, 8, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(35),
                            DescricaoServico = "Troca de trastes",
                            FuncionarioId = 3,
                            Instrumento = "Violão Yamaha",
                            Status = "Pendente",
                            ValorEstimado = 900.0
                        },
                        new
                        {
                            OrdemDeServicoId = 8,
                            ClienteId = 10,
                            CriadoEm = new DateTime(2024, 12, 12, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(38),
                            DescricaoServico = "Revisão",
                            FuncionarioId = 3,
                            Instrumento = "Guitarra Gibson",
                            Status = "Pendente",
                            ValorEstimado = 400.0
                        },
                        new
                        {
                            OrdemDeServicoId = 9,
                            ClienteId = 5,
                            CriadoEm = new DateTime(2024, 12, 9, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(41),
                            DescricaoServico = "Troca de cordas e Manutenções Gerais",
                            FuncionarioId = 3,
                            Instrumento = "Violão DiGiogio",
                            Status = "Em Andamento",
                            ValorEstimado = 643.0
                        },
                        new
                        {
                            OrdemDeServicoId = 10,
                            ClienteId = 7,
                            CriadoEm = new DateTime(2024, 12, 10, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(44),
                            DescricaoServico = "Revisão",
                            FuncionarioId = 3,
                            Instrumento = "Contrabaixo",
                            Status = "Finalizado",
                            ValorEstimado = 700.39999999999998
                        });
                });

            modelBuilder.Entity("API.Models.OrdemDeServico", b =>
                {
                    b.HasOne("API.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");
                });
#pragma warning restore 612, 618
        }
    }
}
