using System;

namespace API.Models;

public class Funcionario
{
  public Funcionario()
  {
    Id = Guid.NewGuid();
    CriadoEm = DateTime.Now;
  }
  public Guid Id { get; set; }
  public string? Nome { get; set; } // Qual instrumento é  -->  Exe.: Guitarra
  public string? Cargo { get; set; }
  public DateTime CriadoEm { get; set; }
}
