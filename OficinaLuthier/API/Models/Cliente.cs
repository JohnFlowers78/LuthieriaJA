using System;

namespace API.Models;

public class Cliente
{
  public Cliente()
  {
    CriadoEm = DateTime.Now;
  }
  public int ClienteId { get; set;}
  public string? Nome { get; set; }
  public string? Telefone { get; set; }
  public string? Cpf { get; set; }
  public DateTime CriadoEm { get; set; }
}