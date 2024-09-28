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
  public string? Nome { get; set; }
  public string? Telefone { get; set; }
  public OrdemDeServico OrdemDeServico { get; set; }
  public DateTime CriadoEm { get; set; }
}
