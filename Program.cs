using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BancoDeDados>(
    options => options.UseSqlite("Data Source=BancoDeDados.db")
);

builder.Services.AddCors(options => options.AddDefaultPolicy((builder) => {
 builder.AllowAnyOrigin().AllowAnyHeader();
}));

var app = builder.Build();

app.UseCors();

app.MapPost("/Colaborador/", async (BancoDeDados bd, Colaborador colaborador) =>
{   
    bd.AddAsync(colaborador);
    await bd.SaveChangesAsync();
    return Results.Ok(colaborador);
});

app.MapGet("/Colaborador/", async (BancoDeDados bd) => {
    var colaboradores = await bd.colaborador.ToListAsync();
    return Results.Ok(colaboradores);
} );

app.MapGet("/Colaborador/{id}", async (BancoDeDados bd, int id) => {
    var colaborador1 = await bd.colaborador.FirstOrDefaultAsync(colaborador => colaborador.Id == id);
    return Results.Ok(colaborador1);
} );

app.MapPut("/Colaborador/editar/{id}", (BancoDeDados bd, int id, Colaborador colaborador) => 
{
    bd.Update(colaborador);
    bd.SaveChangesAsync();
    return Results.Ok(colaborador);
});

app.Run();
