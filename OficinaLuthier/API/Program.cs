using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

app.MapGet("/api/cliente/buscar/{clienteId}", ([FromRoute] int clienteId, [FromServices] AppDataContext ctx) => 
{
  Cliente? cliente = ctx.Clientes.Find(clienteId);
  if (cliente == null)
  {
    return Results.NotFound();
  }
  return Results.Ok(cliente);
});

app.MapDelete("/api/cliente/deletar/{clienteId}", ([FromRoute] int clienteId, [FromServices] AppDataContext ctx) => 
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

app.MapPut("/api/cliente/alterar/{clienteId}", ([FromRoute] int clienteId, [FromBody] Cliente clienteAlterado, [FromServices] AppDataContext ctx) => 
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

app.MapGet("/api/funcionario/buscar/{funcionarioId}", ([FromRoute] int funcionarioId, [FromServices] AppDataContext ctx) => 
{
  Funcionario? funcionario = ctx.Funcionarios.Find(funcionarioId);
  if (funcionario == null)
  {
    return Results.NotFound();
  }
  return Results.Ok(funcionario);
});

app.MapDelete("/api/funcionario/deletar/{funcionarioId}", ([FromRoute] int funcionarioId, [FromServices] AppDataContext ctx) => 
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

app.MapPut("/api/funcionario/alterar/{funcionarioId}", ([FromRoute] int funcionarioId, [FromBody] Funcionario funcAlterado, [FromServices] AppDataContext ctx) => 
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
    return Results.Ok(ctx.OrdensServicos.Include(x => x.Funcionario).Include(x => x.Cliente).ToList());
    // return Results.Ok(ctx.OrdensServicos.ToList());
  }
  return Results.NoContent();
});

app.MapPost("/api/ordemservico/cadastrar", ([FromBody] OrdemDeServico ordemServico, [FromServices] AppDataContext ctx) => 
{
  ctx.OrdensServicos.Add(ordemServico);
  ctx.SaveChanges();
  return Results.Created("Ordem de Servico Criada!", ctx.OrdensServicos.ToList());
});

app.MapGet("/api/ordemservico/buscar/{ordemDeServicoId}", ([FromRoute] int ordemDeServicoId, [FromServices] AppDataContext ctx) => 
{
  OrdemDeServico? ordemServico = ctx.OrdensServicos.Find(ordemDeServicoId);
  if (ordemServico is not null)
  {
    return Results.Ok(ordemServico);
  }
  return Results.NotFound();
});

app.MapDelete("/api/ordemservico/deletar/{ordemDeServicoId}", ([FromRoute] int ordemDeServicoId, [FromServices] AppDataContext ctx) => 
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
app.MapPut("/api/ordemservico/alterar/{ordemDeServicoId}", ([FromRoute] int ordemDeServicoId, [FromBody] OrdemDeServico ordServicoAlterada, [FromServices] AppDataContext ctx) => 
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
// 16 -   .Buscar ordens de serviço por descrições semelhantes
// app.MapGet("/ordemservico/buscar/descricao/{DescricaoServico}", ([FromRoute] string DescricaoServico, [FromServices] AppDataContext ctx) => 
// {
//   List<OrdemDeServico> ordens = ctx.OrdensServicos.Where(x => x.DescricaoServico.Contains(DescricaoServico)).Include(x => x.Funcionario).Include(x => x.Cliente).ToList();
//   if (ordens.Any())
//   {
//     return Results.Ok(ordens);
//   }
//   return Results.NotFound();
// });

// 17 -  .Buscar ordens de serviço com status "Em Andamento"
app.MapGet("/ordemservico/status/emAndamento", ([FromServices] AppDataContext ctx) => 
{
  var ordens = ctx.OrdensServicos.Where(x => x.Status == "Em Andamento").Include(x => x.Funcionario).Include(x => x.Cliente).ToList();
  if (ordens.Any())
  {
    return Results.Ok(ordens);
  }
  return Results.NotFound();
});

// 18 -  .Buscar ordens de serviço com status "Pendente"
app.MapGet("/ordemservico/status/pendente", ([FromServices] AppDataContext ctx) => 
{
  var ordens = ctx.OrdensServicos.Where(x => x.Status == "Pendente").Include(x => x.Funcionario).Include(x => x.Cliente).ToList();
  if (ordens.Any())
  {
    return Results.Ok(ordens);
  }
  return Results.NotFound();
});     

// 19 -   .Buscar manutenções concluídas de um cliente específico     
app.MapGet("/ordemservico/finalizadas/cliente/{clienteId}", ([FromRoute] int clienteId, [FromServices] AppDataContext ctx) => 
{
  var ordens = ctx.OrdensServicos.Where(x => x.ClienteId == clienteId && x.Status == "Finalizado").Include(x => x.Funcionario).Include(x => x.Cliente).ToList();
  if (ordens.Any())
  {
    return Results.Ok(ordens);
  }
  return Results.NotFound();
});

// 20 -   .Buscar todas as manutenções de um cliente (finalizadas ou não) 
app.MapGet("/ordemservico/todas/cliente/{clienteId}", ([FromRoute] int clienteId, [FromServices] AppDataContext ctx) => 
{
  var ordens = ctx.OrdensServicos.Where(x => x.ClienteId == clienteId).Include(x => x.Funcionario).Include(x => x.Cliente).ToList();
  if (ordens.Any())
  {
    return Results.Ok(ordens);
  }
  return Results.NotFound();
});

// 21 -   .Buscar as ordens de serviço realizadas por um funcionário específico                               
app.MapGet("/ordemservico/funcionario/{funcionarioId}", ([FromRoute] int funcionarioId, [FromServices] AppDataContext ctx) => 
{
  var ordens = ctx.OrdensServicos.Where(x => x.FuncionarioId == funcionarioId).Include(x => x.Funcionario).Include(x => x.Cliente).ToList();
  if (ordens.Any())
  {
    return Results.Ok(ordens);
  }
  return Results.NotFound();
});
//==============================================================================

app.UseCors("Acesso Total");

app.Run();

//   ADICIONAR Função de  BUSCA  POR  FUNCIONÁRIOS  Na página de "Listar" de cada Objeto NO  FRONT-END  <--

//==============================================================================
// 16 - Buscar ordens de serviço por descrições semelhantes: Retorna
// ordens de serviço com descrições que correspondem a um parâmetro
// específico.


// 17 - Buscar ordens de serviço com status "Em Andamento": Retorna
// ordens de serviço que estão com status "Em Andamento".
                        //  { --->  OK  <--- }


// 18 - Buscar ordens de serviço com status "Pendente": Retorna
// ordens de serviço que estão com status "Pendente".
                        //  { --->  OK  <--- }


// 19 - Buscar manutenções concluídas de um cliente específico: Retorna
// ordens de serviço concluídas de um cliente, utilizando o ID do cliente.
                        //  { --->  OK  <--- }

// 20 - Buscar todas as manutenções de um cliente (finalizadas ou não):
// Retorna todas as ordens de serviço de um cliente específico,
// independentemente do status.         { --->  OK  <--- }


// 21 - Buscar as ordens de serviço realizadas por um funcionário
// específico: Retorna ordens de serviço vinculadas a um funcionário,
// utilizando o ID do funcionário.         { --->  OK  <--- }
//==============================================================================