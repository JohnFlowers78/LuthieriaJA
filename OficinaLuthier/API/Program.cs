using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Cliente> clientes = new List<Cliente>
{
    new Cliente { Id = Guid.Parse("b195a2c3-f255-4ec9-8577-3ed39a2e8b13"), Nome = "Luis", Telefone = "41984707329" },
    new Cliente { Id = Guid.Parse("a2963d8e-6275-4a4e-a6fc-d6239842e9e6"), Nome = "Victor", Telefone = "41997438180" },
    new Cliente { Id = Guid.Parse("c94d8e42-64cf-47c8-a1e4-e23cba4c7b8e"), Nome = "Carmem", Telefone = "41963457075" },
    new Cliente { Id = Guid.Parse("c72a1d82-57f5-4a85-9b11-8bdb327d7b48"), Nome = "Otavio", Telefone = "41988623514" },
    new Cliente { Id = Guid.Parse("84df3bb1-8f45-49f4-bd3f-5ad0c5b80c62"), Nome = "João Pedro", Telefone = "41999125678" },
    new Cliente { Id = Guid.Parse("b4625d57-3d2e-4a8e-86af-2b8d8f25f9d5"), Nome = "Luisa", Telefone = "43990842030"},
    new Cliente { Id = Guid.Parse("234dcb6f-8e56-48f9-8a57-5c34a40d5a7f"), Nome = "Vitória", Telefone = "47988702098" },
    new Cliente { Id = Guid.Parse("d637f850-29e1-42da-832b-5f7da90d1555"), Nome = "Julia", Telefone = "42988635587" },
    new Cliente { Id = Guid.Parse("3c8d9ff1-5f3a-47b2-97de-f02462d19f2e"), Nome = "Marcela", Telefone = "41995234578" },
    new Cliente { Id = Guid.Parse("7ef248d1-7e58-4e84-b0c8-58dc8891d231"), Nome = "Marcia", Telefone = "45987889339" }
};
List<Funcionario> funcionarios = new List<Funcionario>
{
    new Funcionario{ Id = Guid.Parse("83f5b6e0-2f53-4a8e-90c5-ecf78f0f9e18"), Nome = "Cleiton", Cargo = "Luthier"},
    new Funcionario{ Id = Guid.Parse("b5bb87f1-bd82-4ad4-88df-bf5af30ad45a"), Nome = "Antônio", Cargo = "Luthier Aprendiz"}
};
List<OrdemDeServico> ordensServicos = 
[
    new OrdemDeServico{ Id = Guid.Parse("3c8d9ff1-5f3a-47b2-97de-f02462d19f2e"), DescricaoServico = "Lustragem", ClienteId = Guid.Parse("c94d8e42-64cf-47c8-a1e4-e23cba4c7b8e"), FuncionarioId = Guid.Parse("83f5b6e0-2f53-4a8e-90c5-ecf78f0f9e18"), Instrumento = "Trombone", Status = "Pendente", ValorEstimado = 130.00},
    new OrdemDeServico{ Id = Guid.Parse("7ef298d1-7e68-4e84-b2c8-58dc8891d456"), DescricaoServico = "Revisão", ClienteId = Guid.Parse("c72a1d82-57f5-4a85-9b11-8bdb327d7b48"), FuncionarioId = Guid.Parse("b5bb87f1-bd82-4ad4-88df-bf5af30ad45a") , Instrumento = "Fagote", Status = "Pendente", ValorEstimado = 200.00}
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
//  _____###   Mais Métodos Úteis Para o Nosso Projeto   ###_____

// app.MapPost("", () => 
// {

// });
// app.MapPost("", () => 
// {

// });
// app.MapPost("", () => 
// {

// });

app.Run();