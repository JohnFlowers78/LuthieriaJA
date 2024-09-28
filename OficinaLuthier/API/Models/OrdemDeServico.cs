using System;

namespace API.Models;

public class OrdemDeServico
{
  public Guid Id { get; set; }
  public string? DescricaoServico { get; set; }
  public Guid InstrumentoId { get; set; }
  public Instrumento Instrumento { get; set; }
  public string? Status { get; set; }
  public double ValorEstimado { get; set; }
  public DateTime CriadoEm { get; set; }
}
