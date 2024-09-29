using System;

namespace API.Models;

public class Cliente
{
  public Cliente()
  {
    Id = Guid.NewGuid();
    CriadoEm = DateTime.Now;
  }
  public Guid Id { get; set;}
  public string? Nome { get; set; }
  public string? Telefone { get; set; }
  public string? Cpf { get; set; }
  public DateTime CriadoEm { get; set; }
}
