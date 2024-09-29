using System;

namespace API.Models;

public class Funcionario
{
  public Funcionario()
  {
    Id = Guid.NewGuid();
    CriadoEm = DateTime.Now;
  }
  public string? Nome { get; set; } // Qual instrumento é  -->  Exe.: Guitarra
  public string? Cargo { get; set; }
  public string? Registro { get; set; }
  public DateTime CriadoEm { get; set; }
  public Guid Id { get; set; }
}
