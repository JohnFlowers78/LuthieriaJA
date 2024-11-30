using System;

namespace API.Models;

public class Funcionario
{
  public Funcionario()
  {
    CriadoEm = DateTime.Now;
  }
  public int FuncionarioId { get; set; }
  public string? Nome { get; set; } // Qual instrumento é  -->  Exe.: Guitarra
  public string? Cargo { get; set; }
  public string? NRegistro { get; set; }
  public DateTime CriadoEm { get; set; }
}