using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Database.db"));
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Usuarios.Any())
    {
        context.Usuarios.AddRange(new[]
        {
            new Usuario { Nome = "admin", Senha = "senha123", Status = true },
            new Usuario { Nome = "User1", Senha = "senha123", Status = false },
            new Usuario { Nome = "User2", Senha = "senha123", Status = false },
        });

        context.SaveChanges();
    }

    if (!context.Produtos.Any())
    {
        context.Produtos.AddRange(new[]
        {
            new Produto { Nome = "Produto1", Preco = 10, Status = true, IdUsuarioCadastro = 1 },
            new Produto { Nome = "Produto2", Preco = 20, Status = true, IdUsuarioCadastro = 1 },
        });

        context.SaveChanges();
    }
}


app.UseSwagger();
app.UseCors("AllowAll");
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
