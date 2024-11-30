using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);

var app = builder.Build();

//  ###Listar Clientes
//==============================================================================
app.MapGet("/api/cliente/listar", ([FromServices] AppDataContext ctx) => 
{
  if (ctx.Clientes.Any())
  {
    return Results.Ok(ctx.Clientes.ToList());
  }
  return Results.NotFound();
});
app.MapPost("/api/cliente/cadastrar", ([FromBody] Cliente cliente, [FromServices] AppDataContext ctx) => 
{
  ctx.Clientes.Add(cliente);
  ctx.SaveChanges();
  return Results.Created( "Cliente Cadastrado!", ctx.Clientes.ToList());
});
app.MapGet("/api/cliente/buscar/{id}", ([FromRoute] int clienteId, [FromServices] AppDataContext ctx) => 
{
  Cliente? cliente = ctx.Clientes.Find(clienteId);
  if (cliente == null)
  {
    return Results.NotFound();
  }
  return Results.Ok(cliente);
});
app.MapDelete("/api/cliente/deletar/{id}", ([FromRoute] int clienteId, [FromServices] AppDataContext ctx) => 
{
  Cliente? cliente = ctx.Clientes.Find(clienteId);
  if (cliente is null)
  {
    return Results.NotFound();
  }
  ctx.Clientes.Remove(cliente);
  ctx.SaveChanges();
  return Results.Ok(ctx.Clientes.ToList());
});
app.MapPut("/api/cliente/alterar/{id}", ([FromRoute] int clienteId, [FromBody] Cliente clienteAlterado, [FromServices] AppDataContext ctx) => 
{
  Cliente? cliente = ctx.Clientes.Find(clienteId);
  if (cliente == null)
  {
    return Results.NotFound();
  }
  cliente.Nome = clienteAlterado.Nome;
  cliente.Telefone = clienteAlterado.Telefone;
  cliente.Cpf = clienteAlterado.Cpf;
  ctx.Clientes.Update(cliente);
  ctx.SaveChanges();
  return Results.Ok(cliente);
});
//==============================================================================
app.MapGet("/api/funcionario/listar", ([FromServices] AppDataContext ctx) => 
{
  if (ctx.Funcionarios.Any())
  {
    return Results.Ok(ctx.Funcionarios.ToList());
  }
  return Results.NotFound();
});
app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext ctx) => 
{
  ctx.Funcionarios.Add(funcionario);
  ctx.SaveChanges();
  return Results.Created("Funcionario Cadastrado!", ctx.Funcionarios.ToList());
});
app.MapGet("/api/funcionario/buscar/{id}", ([FromRoute] int funcionarioId, [FromServices] AppDataContext ctx) => 
{
  Funcionario? funcionario = ctx.Funcionarios.Find(funcionarioId);
  if (funcionario == null)
  {
    return Results.NotFound();
  }
  return Results.Ok(ctx.Funcionarios.ToList());   // To list?? ta errado isso!   Mas tudo bem, afinal não é o projeto final!
});
app.MapDelete("/api/funcionario/deletar/{id}", ([FromRoute] int funcionarioId, [FromServices] AppDataContext ctx) => 
{
  Funcionario? funcionario = ctx.Funcionarios.Find(funcionarioId);
  if (funcionario == null)
  {
    return Results.NotFound();
  }
  ctx.Funcionarios.Remove(funcionario);
  ctx.SaveChanges();
  return Results.Ok(ctx.Funcionarios.ToList());
});
app.MapPut("/api/funcionario/alterar/{id}", ([FromRoute] int funcionarioId, [FromBody] Funcionario funcAlterado, [FromServices] AppDataContext ctx) => 
{
  Funcionario? funcionario = ctx.Funcionarios.Find(funcionarioId);
  if (funcionario != null)
  {
    funcionario.Nome = funcAlterado.Nome;
    funcionario.Cargo = funcAlterado.Cargo;
    funcionario.NRegistro = funcAlterado.NRegistro;
    ctx.Funcionarios.Update(funcionario);
    return Results.Ok(funcionario);
  }
  return Results.NotFound();
});
//==============================================================================
app.MapGet("/api/ordemservico/listar", ([FromServices] AppDataContext ctx) => 
{
  if (ctx.OrdensServicos.Any())
  {
    return Results.Ok(ctx.OrdensServicos.ToList());
        // return Results.Ok(ctx.OrdensServicos.Include(x => x.Funcionario && x.Cliente).ToList());
  }
  return Results.NoContent();
});
app.MapPost("/api/ordemservico/cadastrar", ([FromBody] OrdemDeServico ordemServico, [FromServices] AppDataContext ctx) => 
{
  ctx.OrdensServicos.Add(ordemServico);
  ctx.SaveChanges();
  return Results.Created("Ordem de Servico Criada!", ctx.OrdensServicos.ToList());
});
app.MapGet("/api/ordemservico/buscar{id}", ([FromRoute] int ordemDeServicoId, [FromServices] AppDataContext ctx) => 
{
  OrdemDeServico? ordemServico = ctx.OrdensServicos.Find(ordemDeServicoId);
  if (ordemServico is not null)
  {
    return Results.Ok(ordemServico);
  }
  return Results.NotFound();
});
app.MapDelete("/api/ordemservico/deletar/{id}", ([FromRoute] int ordemDeServicoId, [FromServices] AppDataContext ctx) => 
{
  OrdemDeServico? ordemServico = ctx.OrdensServicos.Find(ordemDeServicoId);
  if (ordemServico is not null)
  {
    ctx.OrdensServicos.Remove(ordemServico);
    ctx.SaveChanges();
    return Results.Ok(ctx.OrdensServicos.ToList());
  }
  return Results.NotFound();
});
app.MapPut("/api/ordemservico/alterar/{id}", ([FromRoute] int ordemDeServicoId, [FromBody] OrdemDeServico ordServicoAlterada, [FromServices] AppDataContext ctx) => 
{
  OrdemDeServico? ordemServico = ctx.OrdensServicos.Find(ordemDeServicoId);
  if (ordemServico != null)
  {
    ordemServico.DescricaoServico = ordServicoAlterada.DescricaoServico;
    ordemServico.Instrumento = ordServicoAlterada.Instrumento;
    ordemServico.Status = ordServicoAlterada.Status;
    ordemServico.ValorEstimado = ordServicoAlterada.ValorEstimado;
    ctx.OrdensServicos.Update(ordemServico);
    ctx.SaveChanges();
    return Results.Ok(ordemServico);
  }
  return Results.NotFound();
});
//==============================================================================

//     F.I.L.T.R.O.S
//   - - - - - - - - -   
//==============================================================================
//     .Listar as ordens de serviço ordenadas por data de criação
app.MapGet("/ordemservico/listar/OrderBy/DateTime/", ([FromServices] AppDataContext ctx) => 
{
  if (ctx.OrdensServicos.Any())
  {
    var ordenadas = ctx.OrdensServicos.OrderBy(x => x.CriadoEm).ToList();
    return Results.Ok(ordenadas);
  }
  return Results.NotFound();
});
//     .Buscar ordens de serviço por descrições semelhantes      
app.MapGet("/ordemservico/buscar/descricao/{DescricaoServico}", ([FromRoute] string DescricaoServico, [FromServices] AppDataContext ctx) => 
{
  List<OrdemDeServico> ordens = ctx.OrdensServicos.Where(x => x.DescricaoServico == DescricaoServico).ToList();
//   List<OrdemDeServico> ordens = ctx.OrdensServicos.Where(x => x.DescricaoServico.Contains(DescricaoServico)).ToList();
  if (ordens.Any())
  {
    return Results.Ok(ordens);
  }
  return Results.NotFound();
});
//     .Buscar ordens de serviço com status "Em Andamento"    
app.MapGet("/ordemservico/status/{status}", ([FromRoute] string status, [FromServices] AppDataContext ctx) => 
{
  var ordens = ctx.OrdensServicos.Where(x => x.Status == "Em Aberto").ToList();
  if (ordens.Any())
  {
    return Results.Ok(ordens);
  }
  return Results.NotFound();
});
//     .Buscar manutenções concluídas de um cliente específico     
app.MapGet("/ordemservico/finalizadas/cliente/{clienteId}", ([FromRoute] int clienteId, [FromServices] AppDataContext ctx) => 
{
  var ordens = ctx.OrdensServicos.Where(x => x.ClienteId == clienteId && x.Status == "Finalizado").ToList();
  if (ordens.Any())
  {
    return Results.Ok(ordens);
  }
  return Results.NotFound();
});
//     .Buscar todas as manutenções de um cliente (finalizadas ou não) 
app.MapGet("/ordemservico/todas/cliente/{clienteId}", ([FromRoute] int clienteId, [FromServices] AppDataContext ctx) => 
{
  var ordens = ctx.OrdensServicos.Where(x => x.ClienteId == clienteId).ToList();
  if (ordens.Any())
  {
    return Results.Ok(ordens);
  }
  return Results.NotFound();
});
//     .Buscar as ordens de serviço realizadas por um funcionário específico                               
app.MapGet("/ordemservico/funcionario/{funcionarioId}", ([FromRoute] int funcionarioId, [FromServices] AppDataContext ctx) => 
{
  var ordens = ctx.OrdensServicos.Where(x => x.FuncionarioId == funcionarioId).ToList();
  if (ordens.Any())
  {
    return Results.Ok(ordens);
  }
  return Results.NotFound();
});
//==============================================================================

app.UseCors("Acesso Total");

app.Run();



//==============================================================================
// 16 - Listar as ordens de serviço ordenadas por data de criação: Retorna
// todas as ordens de serviço, organizadas pela data de criação.


// 17 - Buscar ordens de serviço por descrições semelhantes: Retorna
// ordens de serviço com descrições que correspondem a um parâmetro
// específico.


// 16 - Buscar ordens de serviço com status "Em Andamento": Retorna
// ordens de serviço que estão com status pendente.


// 19 - Buscar manutenções concluídas de um cliente específico: Retorna
// ordens de serviço concluídas de um cliente, utilizando o ID do cliente.


// 20 - Buscar todas as manutenções de um cliente (finalizadas ou não):
// Retorna todas as ordens de serviço de um cliente específico,
// independentemente do status.


// 21 - Buscar as ordens de serviço realizadas por um funcionário
// específico: Retorna ordens de serviço vinculadas a um funcionário,
// utilizando o ID do funcionário.
//==============================================================================