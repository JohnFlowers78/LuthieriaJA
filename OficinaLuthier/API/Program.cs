using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<Cliente> clientes = [
    new Cliente { Nome = "Luis", Telefone = "41984707329" },
    new Cliente { Nome = "Victor", Telefone = "41997438180" },
    new Cliente { Nome = "Carmem", Telefone = "41963457075" },
    new Cliente { Nome = "Otavio", Telefone = "41988623514" },
    new Cliente { Nome = "João Pedro", Telefone = "41999125678" },
    new Cliente { Nome = "Óculos de Sol", Telefone = "43990842030"},
    new Cliente { Nome = "Mochila", Telefone = "47988702098" },
    new Cliente { Nome = "Relógio", Telefone = "42988635587" },
    new Cliente { Nome = "Camisa Social", Telefone = "41995234578" },
    new Cliente { Nome = "Tênis Casual", Telefone = "45987889339" }
];
List<Funcionario> funcionarios = 
[
    new Funcionario{Nome = "Cleiton", Cargo = "Luthier"},
    new Funcionario{Nome = "Antônio", Cargo = "Luthier Aprendiz"}
];
List<OrdemDeServico> ordensServicos = 
[
    new OrdemDeServico{DescricaoServico = "Lustragem", FuncionarioId = null, Instrumento = "Trombone", Status = "Pendente", ValorEstimado = 130.00},
    new OrdemDeServico{DescricaoServico = "Revisão", FuncionarioId = null, Instrumento = "Fagote", Status = "Pendente", ValorEstimado = 200.00}
];


app.MapGet("/cliente", () =>
{
    return Results.Ok(clientes.ToList());
});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});
app.MapPost("", () => {

});

app.Run();

