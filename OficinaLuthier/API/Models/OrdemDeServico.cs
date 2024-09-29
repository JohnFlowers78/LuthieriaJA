using System;

namespace API.Models;

public class OrdemDeServico
{
  public OrdemDeServico()
  {
    Id = Guid.NewGuid();
    CriadoEm = DateTime.Now;
  }
  public string? DescricaoServico { get; set; }
  public string? Instrumento { get; set; }
   public string? Status { get; set; }
  public double ValorEstimado { get; set; }
  public Guid ClienteId { get; set; }    
  public Cliente? Cliente { get; set; }
  public Guid FuncionarioId { get; set; }
  public Funcionario? Funcionario { get; set; }
  public DateTime CriadoEm { get; set; }
  public Guid Id { get; set; }
}
