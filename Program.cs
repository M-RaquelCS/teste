using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BancoDeDados>(
    options => options.UseSqlite("Data Source=BancoDeDados.db")
);

var app = builder.Build();

app.MapPost("/Colaborador/", (BancoDeDados bd, Colaborador colaborador) =>
{   
    bd.Add(colaborador);
    bd.SaveChangesAsync();
    return Results.Ok(colaborador);
});

app.MapPut("/Colaborador/{id}", (BancoDeDados bd, int id, Colaborador colaborador) => 
{
    bd.Update(colaborador);
    bd.SaveChangesAsync();
    return Results.Ok(colaborador);
});

app.Run();
