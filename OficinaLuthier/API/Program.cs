using API.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Cliente> clientes = 
[
    new Cliente{Nome = "Cleiton", Email = "cleiton@gmail.com", Telefone = "516532146"},
    new Cliente{Nome = "Antônio", Email = "antonio@gmail.com", Telefone = "516532564"}
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

app.Run();

