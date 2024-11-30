using System;

namespace API.Models;

public class OrdemDeServico
{
  public OrdemDeServico()
  {
    CriadoEm = DateTime.Now;
  }
  public int OrdemDeServicoId { get; set; }
  public string? DescricaoServico { get; set; }
  public string? Instrumento { get; set; }
   public string? Status { get; set; }
  public double ValorEstimado { get; set; }
  public Cliente? Cliente { get; set; }
  public int ClienteId { get; set; } 
  public Funcionario? Funcionario { get; set; }
  public int FuncionarioId { get; set; }
  public DateTime CriadoEm { get; set; }
}