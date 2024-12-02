using System;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDataContext : DbContext
{
  public DbSet<Cliente> Clientes { get; set; }
  public DbSet<Funcionario> Funcionarios { get; set; }
  public DbSet<OrdemDeServico> OrdensServicos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=JoaoF_AlissonF.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>().HasData(
            new Funcionario { FuncionarioId = 1, Nome = "Cleiton", Cargo = "Luthier", NRegistro = "333", CriadoEm = DateTime.Now.AddDays(2) },
            new Funcionario { FuncionarioId = 2, Nome = "Antônio", Cargo = "Luthier Aprendiz", NRegistro = "756", CriadoEm = DateTime.Now.AddDays(63) },
            new Funcionario { FuncionarioId = 3, Nome = "Paulo", Cargo = "Luthier", NRegistro = "986", CriadoEm = DateTime.Now.AddDays(77) }
        );
        modelBuilder.Entity<Cliente>().HasData(
            new Cliente { ClienteId = 1, Nome = "Luis", Telefone = "41984707329", Cpf = "1234", CriadoEm = DateTime.Now.AddDays(7) },
            new Cliente { ClienteId = 2, Nome = "Victor", Telefone = "41997438180", Cpf = "5678", CriadoEm = DateTime.Now.AddDays(8) },
            new Cliente { ClienteId = 3, Nome = "Carmem", Telefone = "41963457075", Cpf = "9101", CriadoEm = DateTime.Now.AddDays(8) },
            new Cliente { ClienteId = 4, Nome = "Otavio", Telefone = "41988623514", Cpf = "1121", CriadoEm = DateTime.Now.AddDays(8) },
            new Cliente { ClienteId = 5, Nome = "João Pedro", Telefone = "41999125678", Cpf = "3141", CriadoEm = DateTime.Now.AddDays(9) },
            new Cliente { ClienteId = 6, Nome = "Luisa", Telefone = "43990842030", Cpf = "5161", CriadoEm = DateTime.Now.AddDays(9) },
            new Cliente { ClienteId = 7, Nome = "Vitória", Telefone = "47988702098", Cpf = "7181", CriadoEm = DateTime.Now.AddDays(10) },
            new Cliente { ClienteId = 8, Nome = "Julia", Telefone = "42988635587", Cpf = "9202", CriadoEm = DateTime.Now.AddDays(10) },
            new Cliente { ClienteId = 9, Nome = "Marcela", Telefone = "41995234578", Cpf = "1222", CriadoEm = DateTime.Now.AddDays(12) },
            new Cliente { ClienteId = 10, Nome = "Marcia", Telefone = "45987889339", Cpf = "3242", CriadoEm = DateTime.Now.AddDays(12) }
        );
        modelBuilder.Entity<OrdemDeServico>().HasData(
            new OrdemDeServico { OrdemDeServicoId = 1, DescricaoServico = "Troca da Cortiça", Instrumento = "Clarinete", Status = "Finalizado", ValorEstimado = 106.60, ClienteId = 1, FuncionarioId = 1, CriadoEm = DateTime.Now.AddDays(7) },
            new OrdemDeServico { OrdemDeServicoId = 2, DescricaoServico = "Realinhamento do Braço", Instrumento = "Violão Takamine", Status = "Pendente", ValorEstimado = 560.00, ClienteId = 2, FuncionarioId = 2, CriadoEm = DateTime.Now.AddDays(8) },
            new OrdemDeServico { OrdemDeServicoId = 3, DescricaoServico = "Lustragem", Instrumento = "Trombone", Status = "Pendente", ValorEstimado = 130.00, ClienteId = 3, FuncionarioId = 1, CriadoEm = DateTime.Now.AddDays(8) },
            new OrdemDeServico { OrdemDeServicoId = 4, DescricaoServico = "Troca de cordas e Manutenções Gerais", Instrumento = "Ibanez", Status = "Em Andamento", ValorEstimado = 570.00, ClienteId = 6, FuncionarioId = 1, CriadoEm = DateTime.Now.AddDays(9) },
            new OrdemDeServico { OrdemDeServicoId = 5, DescricaoServico = "Revisão", Instrumento = "Fagote", Status = "Pendente", ValorEstimado = 200.00, ClienteId = 4, FuncionarioId = 2, CriadoEm = DateTime.Now.AddDays(8) },
            new OrdemDeServico { OrdemDeServicoId = 6, DescricaoServico = "Realinhamento do Braço", Instrumento = "Takamine", Status = "Pendente", ValorEstimado = 500.00, ClienteId = 8, FuncionarioId = 2, CriadoEm = DateTime.Now.AddDays(10) },
            new OrdemDeServico { OrdemDeServicoId = 7, DescricaoServico = "Troca de trastes", Instrumento = "Violão Yamaha", Status = "Pendente", ValorEstimado = 900.00, ClienteId = 3, FuncionarioId = 3, CriadoEm = DateTime.Now.AddDays(8) },
            new OrdemDeServico { OrdemDeServicoId = 8, DescricaoServico = "Revisão", Instrumento = "Guitarra Gibson", Status = "Pendente", ValorEstimado = 400.00, ClienteId = 10, FuncionarioId = 3, CriadoEm = DateTime.Now.AddDays(12) },
            new OrdemDeServico { OrdemDeServicoId = 9, DescricaoServico = "Troca de cordas e Manutenções Gerais", Instrumento = "Violão DiGiogio", Status = "Em Andamento", ValorEstimado = 643.00, ClienteId = 5, FuncionarioId = 3, CriadoEm = DateTime.Now.AddDays(9) },
            new OrdemDeServico { OrdemDeServicoId = 10, DescricaoServico = "Revisão", Instrumento = "Contrabaixo", Status = "Finalizado", ValorEstimado = 700.40, ClienteId = 7, FuncionarioId = 3, CriadoEm = DateTime.Now.AddDays(10) }
        );
    }
}
