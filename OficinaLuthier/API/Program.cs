using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<Cliente> clientes = [
    new Cliente { Id = Guid.Parse("1"), Nome = "Luis", Telefone = "41984707329" },
    new Cliente { Id = Guid.Parse("2"), Nome = "Victor", Telefone = "41997438180" },
    new Cliente { Id = Guid.Parse("3"), Nome = "Carmem", Telefone = "41963457075" },
    new Cliente { Id = Guid.Parse("4"), Nome = "Otavio", Telefone = "41988623514" },
    new Cliente { Id = Guid.Parse("5"), Nome = "João Pedro", Telefone = "41999125678" },
    new Cliente { Id = Guid.Parse("6"), Nome = "Luisa", Telefone = "43990842030"},
    new Cliente { Id = Guid.Parse("7"), Nome = "Vitória", Telefone = "47988702098" },
    new Cliente { Id = Guid.Parse("8"), Nome = "Julia", Telefone = "42988635587" },
    new Cliente { Id = Guid.Parse("9"), Nome = "Marcela", Telefone = "41995234578" },
    new Cliente { Id = Guid.Parse("10"), Nome = "Marcia", Telefone = "45987889339" }
];
List<Funcionario> funcionarios = 
[
    new Funcionario{ Id = Guid.Parse("1"), Nome = "Cleiton", Cargo = "Luthier"},
    new Funcionario{ Id = Guid.Parse("2"), Nome = "Antônio", Cargo = "Luthier Aprendiz"}
];
List<OrdemDeServico> ordensServicos = 
[
    new OrdemDeServico{ Id = Guid.Parse("1"), DescricaoServico = "Lustragem", FuncionarioId = Guid.Parse("1"), Instrumento = "Trombone", Status = "Pendente", ClienteId = Guid.Parse("1"), ValorEstimado = 130.00},
    new OrdemDeServico{ Id = Guid.Parse("2"), DescricaoServico = "Revisão", FuncionarioId = Guid.Parse("2"), Instrumento = "Fagote", Status = "Pendente", ClienteId = Guid.Parse("3"), ValorEstimado = 200.00}
];

// ## Listar
app.MapGet("/cliente", () =>
{
    if(clientes.Count == 0){
        return Results.NotFound();
    }
    return Results.Ok(clientes.ToList());
});

//## Cadastrar
app.MapPost("/cliente", ([FromBody] Cliente cliente) => {
    Cliente clienteTemp = cliente;
    var confere = clientes.FirstOrDefault(x => x.Cpf == clienteTemp.Cpf);
    if (confere == null){
        clientes.Add(clienteTemp);
        return Results.Ok(clienteTemp);
    }
    return Results.BadRequest("Cliente já cadastrado");
});

//## Buscar 
app.MapGet("cliente/{cpf}", ([FromRoute] string cpf) => {
    Cliente cliente = clientes.FirstOrDefault(x => x.Cpf == cpf);
    if (cliente == null){
        return Results.NotFound("Cliente não encontrado");
    }
    return Results.Ok(cliente);
});


//## Alterar
app.MapPut("cliente/{cpf}", ([FromBody] Cliente cliente) => {
    Cliente clienteTemp = clientes.FirstOrDefault(x => x.Cpf == cliente.Cpf);
    if (clienteTemp == null){
        return Results.NotFound();
    }
    clienteTemp.Nome = cliente.Nome;
    clienteTemp.Telefone = cliente.Telefone;
    clientes.Add(clienteTemp);
    return Results.Ok(clienteTemp);
});

//## Deletar
app.MapDelete("cliente/cpf", ([FromRoute] string cpf) => {
    Cliente cliente = clientes.FirstOrDefault(x => x.Cpf == cpf);
    if (cliente == null){
        return Results.NotFound("Cliente não encontrado");
    }
    clientes.Remove(cliente);
    return Results.Ok(cliente);
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

