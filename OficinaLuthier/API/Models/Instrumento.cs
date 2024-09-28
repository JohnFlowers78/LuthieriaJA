using System;

namespace API.Models;

public class Instrumento
{
  public Instrumento()
  {
    Id = Guid.NewGuid();
    CriadoEm = DateTime.Now;
  }
  public Guid Id { get; set; }
  public string? Tipo { get; set; }   // Qual instrumento é  -->  Exe.: Guitarra
  public string? Marca { get; set; }
  public Guid ClienteId { get; set; }  // Esse atributo é para a tabela do ORM EF   -->  tipo Guid ou string (dependendo de como foi declarado la na classe dele)
  public Cliente Cliente { get; set; }
  public DateTime CriadoEm { get; set; }
}
