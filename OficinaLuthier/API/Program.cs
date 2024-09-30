using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<Cliente> clientes = 
[   
    new Cliente { Nome = "Luis", Telefone = "41984707329", Cpf = "1234", Id = Guid.Parse("b195a2c3-f255-4ec9-8577-3ed39a2e8b13") },
    new Cliente { Nome = "Victor", Telefone = "41997438180", Cpf = "5678", Id = Guid.Parse("a2963d8e-6275-4a4e-a6fc-d6239842e9e6") },
    new Cliente { Nome = "Carmem", Telefone = "41963457075", Cpf = "9101", Id = Guid.Parse("c94d8e42-64cf-47c8-a1e4-e23cba4c7b8e") },
    new Cliente { Nome = "Otavio", Telefone = "41988623514", Cpf = "1121", Id = Guid.Parse("c72a1d82-57f5-4a85-9b11-8bdb327d7b48") },
    new Cliente { Nome = "João Pedro", Telefone = "41999125678", Cpf = "3141", Id = Guid.Parse("84df3bb1-8f45-49f4-bd3f-5ad0c5b80c62") },
    new Cliente { Nome = "Luisa", Telefone = "43990842030", Cpf = "5161", Id = Guid.Parse("b4625d57-3d2e-4a8e-86af-2b8d8f25f9d5") },
    new Cliente { Nome = "Vitória", Telefone = "47988702098", Cpf = "7181", Id = Guid.Parse("234dcb6f-8e56-48f9-8a57-5c34a40d5a7f") },
    new Cliente { Nome = "Julia", Telefone = "42988635587", Cpf = "9202", Id = Guid.Parse("d637f850-29e1-42da-832b-5f7da90d1555") },
    new Cliente { Nome = "Marcela", Telefone = "41995234578", Cpf = "1222", Id = Guid.Parse("3c8d9ff1-5f3a-47b2-97de-f02462d19f2e") },
    new Cliente { Nome = "Marcia", Telefone = "45987889339", Cpf = "3242", Id = Guid.Parse("7ef248d1-7e58-4e84-b0c8-58dc8891d231") }
];

List<Funcionario> funcionarios = new List<Funcionario>
{
    new Funcionario{ Id = Guid.Parse("83f5b6e0-2f53-4a8e-90c5-ecf78f0f9e18"), Nome = "Cleiton", Cargo = "Luthier" },
    new Funcionario{ Id = Guid.Parse("b5bb87f1-bd82-4ad4-88df-bf5af30ad45a"), Nome = "Antônio", Cargo = "Luthier Aprendiz" },
    new Funcionario{ Id = Guid.Parse("a5aa78f1-bd82-4ad4-88df-bf5af30ad45a"), Nome = "Paulo", Cargo = "Luthier" }
};

List<OrdemDeServico> ordensServicos = 
[
    new OrdemDeServico { DescricaoServico = "Troca da Cortiça", Instrumento = "Clarinete", Status = "Finalizado", ValorEstimado = 106.60, ClienteId = Guid.Parse("b195a2c3-f255-4ec9-8577-3ed39a2e8b13"), FuncionarioId = Guid.Parse("83f5b6e0-2f53-4a8e-90c5-ecf78f0f9e18"), Id = Guid.NewGuid() },
    new OrdemDeServico { DescricaoServico = "Realinhamento do Braço", Instrumento = "Violão Takamine", Status = "Pendente", ValorEstimado = 560.00, ClienteId = Guid.Parse("a2963d8e-6275-4a4e-a6fc-d6239842e9e6"), FuncionarioId = Guid.Parse("b5bb87f1-bd82-4ad4-88df-bf5af30ad45a"), Id = Guid.NewGuid() },
    new OrdemDeServico { DescricaoServico = "Lustragem", Instrumento = "Trombone", Status = "Pendente", ValorEstimado = 130.00, ClienteId = Guid.Parse("c94d8e42-64cf-47c8-a1e4-e23cba4c7b8e"), FuncionarioId = Guid.Parse("83f5b6e0-2f53-4a8e-90c5-ecf78f0f9e18"), Id = Guid.NewGuid() },
    new OrdemDeServico { DescricaoServico = "Troca de cordas e Manutenções Gerais", Instrumento = "Ibanez", Status = "Em Andamento", ValorEstimado = 570.00, ClienteId = Guid.Parse("b4625d57-3d2e-4a8e-86af-2b8d8f25f9d5"), FuncionarioId = Guid.Parse("83f5b6e0-2f53-4a8e-90c5-ecf78f0f9e18"), Id = Guid.NewGuid() },
    new OrdemDeServico { DescricaoServico = "Revisão", Instrumento = "Fagote", Status = "Pendente", ValorEstimado = 200.00, ClienteId = Guid.Parse("c72a1d82-57f5-4a85-9b11-8bdb327d7b48"), FuncionarioId = Guid.Parse("b5bb87f1-bd82-4ad4-88df-bf5af30ad45a"), Id = Guid.NewGuid() },
    new OrdemDeServico { DescricaoServico = "Realinhamento do Braço", Instrumento = "Takamine", Status = "Pendente", ValorEstimado = 500.00, ClienteId = Guid.Parse("d637f850-29e1-42da-832b-5f7da90d1555"), FuncionarioId = Guid.Parse("b5bb87f1-bd82-4ad4-88df-bf5af30ad45a"), Id = Guid.NewGuid() },
    new OrdemDeServico { DescricaoServico = "Troca de trastes", Instrumento = "Violão Yamaha", Status = "Pendente", ValorEstimado = 900.00, ClienteId = Guid.Parse("c94d8e42-64cf-47c8-a1e4-e23cba4c7b8e"), FuncionarioId = Guid.Parse("a5aa78f1-bd82-4ad4-88df-bf5af30ad45a"), Id = Guid.NewGuid() },
    new OrdemDeServico { DescricaoServico = "Revisão", Instrumento = "Guitarra Gibson", Status = "Pendente", ValorEstimado = 400.00, ClienteId = Guid.NewGuid(), FuncionarioId = Guid.Parse("a5aa78f1-bd82-4ad4-88df-bf5af30ad45a"), Id = Guid.NewGuid() },
    new OrdemDeServico { DescricaoServico = "Troca de cordas e Manutenções Gerais", Instrumento = "Violão DiGiogio", Status = "Em Andamento", ValorEstimado = 643.00, ClienteId = Guid.Parse("84df3bb1-8f45-49f4-bd3f-5ad0c5b80c62"), FuncionarioId = Guid.Parse("a5aa78f1-bd82-4ad4-88df-bf5af30ad45a"), Id = Guid.NewGuid() },
    new OrdemDeServico { DescricaoServico = "Revisão", Instrumento = "Contrabaixo", Status = "Finalizado", ValorEstimado = 700.40, ClienteId = Guid.Parse("234dcb6f-8e56-48f9-8a57-5c34a40d5a7f"), FuncionarioId = Guid.Parse("a5aa78f1-bd82-4ad4-88df-bf5af30ad45a"), Id = Guid.NewGuid() }
];

//______________________________________________________________________________
//  ###Listar Clientes
app.MapGet("/cliente", () =>
{
    if(clientes.Count == 0){
        return Results.NotFound();
    }
    return Results.Ok(clientes.ToList());
});
//  ###Cadastrar Clientes
app.MapPost("/cliente/cadastrar", ([FromBody] Cliente cliente) => {
    Cliente clienteTemp = cliente;
    var confere = clientes.FirstOrDefault(x => x.Cpf == clienteTemp.Cpf);
    if (confere == null){
        clientes.Add(clienteTemp);
        return Results.Ok(clienteTemp);
    }
    return Results.BadRequest("Cliente já cadastrado");
});
//  ###Buscar Clientes
app.MapGet("cliente/buscar/{cpf}", ([FromRoute] string cpf) => {
    Cliente? cliente = clientes.FirstOrDefault(x => x.Cpf == cpf);
    if (cliente == null){
        return Results.NotFound("Cliente não encontrado");
    }
    return Results.Ok(cliente);
});
//  ###Alterar Clientes
app.MapPut("cliente/alterar/{cpf}", ([FromBody] Cliente cliente) => {
    Cliente? clienteTemp = clientes.FirstOrDefault(x => x.Cpf == cliente.Cpf);
    if (clienteTemp == null){
        return Results.NotFound();
    }
    clienteTemp.Nome = cliente.Nome;
    clienteTemp.Telefone = cliente.Telefone;
    clientes.Add(clienteTemp);
    return Results.Ok(clienteTemp);
});
//  ###Deletar Clientes
app.MapDelete("cliente/deletar/{cpf}", ([FromRoute] string cpf) => {
    Cliente? cliente = clientes.FirstOrDefault(x => x.Cpf == cpf);
    if (cliente == null){
        return Results.NotFound("Cliente não encontrado");
    }
    clientes.Remove(cliente);
    return Results.Ok(cliente);
});
//______________________________________________________________________________
//  ###Listar Funcionarios
app.MapGet("/funcionario", () => {
    return funcionarios;
});
//  ###Cadastrar Funcionarios
app.MapPost("/funcionario/cadastrar", ([FromBody] Funcionario funcionario) => 
{
    funcionarios.Add(funcionario);
    return Results.Created("", funcionarios);
});
//  ###Buscar Funcionarios
app.MapGet("/funcionario/buscar/{registro}", ([FromRoute] string registro) => 
{
    Funcionario? funcionario = funcionarios.Find(x => x.Registro == registro);
    if (funcionario != null)
    {
        return Results.Ok(funcionario);
    }
    return Results.NotFound();
});
//  ###Deletar Funcionarios
app.MapDelete("/funcionario/deletar/{registro}", ([FromRoute] string registro) => 
{
    Funcionario? funcionario = funcionarios.Find(x => x.Registro == registro);
    if (funcionario != null){
        funcionarios.Remove(funcionario);
        return Results.Ok(funcionarios);
    }
    return Results.NotFound();
});
//  ###Alterar Funcionarios
app.MapPut("/funcionario/alterar/{registro}", ([FromBody] Funcionario funcionarioAlterado) => 
{
    Funcionario? funcionario = funcionarios.Find(x => x.Id == funcionarioAlterado.Id);
    if (funcionario != null)
    {
        funcionario.Nome = funcionarioAlterado.Nome;
        funcionario.Cargo = funcionarioAlterado.Cargo;
        funcionario.Registro = funcionarioAlterado.Registro;
        return Results.Ok(funcionario);
    }
    return Results.NotFound();
});

//______________________________________________________________________________
//  ###Listar Ordens_De_Serviços
app.MapGet("/ordemservico", () => 
{
    return ordensServicos;
});
//  ###Cadastrar Ordens_De_Serviços
app.MapPost("/ordemservico/cadastrar", ([FromBody] OrdemDeServico ordermDeServico) => 
{
    ordensServicos.Add(ordermDeServico);
    return Results.Created("", ordensServicos);
});
//  ###Buscar Ordens_De_Serviços
app.MapGet("/ordemservico/buscar/{id}", ([FromRoute] Guid id) => 
{
    OrdemDeServico? ordemDeServico = ordensServicos.Find(x => x.Id == id);
    if (ordemDeServico != null)
    {
        return Results.Ok(ordemDeServico);
    }
    return Results.NotFound();
});
//  ###Deletar Ordens_De_Serviços
app.MapDelete("/ordemservico/deletar/{id}", ([FromRoute] Guid id) => 
{
    OrdemDeServico? ordemDeServico = ordensServicos.Find(x => x.Id == id);
    if (ordemDeServico != null)
    {
        ordensServicos.Remove(ordemDeServico);
        return Results.Ok(ordensServicos);
    }
    return Results.NotFound();
});
//  ###Alterar Ordens_De_Serviços
app.MapPut("/ordemservico/alterar", ([FromBody] OrdemDeServico ordemDeServicoAlterada) => 
{
    OrdemDeServico? ordemDeServico = ordensServicos.Find(x => x.Id == ordemDeServicoAlterada.Id);
    if (ordemDeServico != null)
    {
        ordemDeServico.DescricaoServico = ordemDeServicoAlterada.DescricaoServico;
        ordemDeServico.Instrumento = ordemDeServicoAlterada.Instrumento;
        ordemDeServico.Status = ordemDeServicoAlterada.Status;
        ordemDeServico.ValorEstimado = ordemDeServicoAlterada.ValorEstimado;
        return Results.Ok(ordemDeServico);
    }
    return Results.NotFound();
});
//______________________________________________________________________________
//  _____###   Filtros de Pesquisa Para o Nosso Projeto   ###_____

//      Listar as ordens de serviço ordenadas por data de criação
app.MapGet("/", () =>
{
    var ordensOrdenadas = ordensServicos.OrderBy(o => o.CriadoEm).ToList();
    if(ordensOrdenadas.Count == 0){
        return Results.NotFound();
    }
    return Results.Ok(ordensOrdenadas);
});

//       Buscar ordens de serviço por descrições semelhantes
app.MapGet("/buscar/{descricao}", (string descricao) =>
{
    var resultado = ordensServicos
        .Where(o => o.DescricaoServico != null && o.DescricaoServico.Contains(descricao, StringComparison.OrdinalIgnoreCase))
        .ToList();
    if(resultado.Count == 0){
        return Results.NotFound();
    }
    return Results.Ok(resultado);
});

//       Buscar ordens de serviço com status "Em Aberto"
app.MapGet("/status/aberto", () =>
{
    var emAberto = ordensServicos.Where(o => o.Status == "Pendente").ToList();
    if(emAberto.Count == 0){
        return Results.NotFound();
    }
    return Results.Ok(emAberto);
});

//       Buscar manutenções concluídas de um cliente específico
app.MapGet("/cliente/{clienteId}/concluidas", (Guid clienteId) =>
{
    var concluidas = ordensServicos
        .Where(o => o.ClienteId == clienteId && o.Status == "Concluída")
        .ToList();
    if(concluidas.Count == 0){
        return Results.NotFound();
    }
    return Results.Ok(concluidas);
});

//      Buscar todas as manutenções de um cliente (finalizadas ou não)
app.MapGet("/cliente/{clienteId}/todas", (Guid clienteId) =>
{
    var todas = ordensServicos
        .Where(o => o.ClienteId == clienteId)
        .ToList();
    if(todas.Count == 0){
        return Results.NotFound();
    }
    return Results.Ok(todas);
});

//      Buscar as ordens de serviço realizadas por um funcionário específico
app.MapGet("/funcionario/{funcionarioId}/concertos", (Guid funcionarioId) =>
{
    var concertos = ordensServicos
        .Where(o => o.FuncionarioId == funcionarioId)
        .ToList();
    if(concertos.Count == 0){
        return Results.NotFound();
    }
    return Results.Ok(concertos);
});