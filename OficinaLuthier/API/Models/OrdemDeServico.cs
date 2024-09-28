using System;

namespace API.Models;

public class OrdemDeServico
{
  public OrdemDeServico()
  {
    Id = Guid.NewGuid();
    CriadoEm = DateTime.Now;
  }
  public Guid Id { get; set; }
  public string? DescricaoServico { get; set; }
  public string? Instrumento { get; set; }
   public string? Status { get; set; }
  public double ValorEstimado { get; set; }
  public Guid? ClienteId { get; set; }     // Tirar a "não obrigatoriedade!"
  public Cliente Cliente { get; set; }
  public Guid? FuncionarioId { get; set; }    // Tirar a "não obrigatoriedade!"  //Como não temos database, ainda não temos como criar essas classes com ids prórpios
  public Funcionario Funcionario { get; set; }
  public DateTime CriadoEm { get; set; }
}
