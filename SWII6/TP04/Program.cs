using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using TP04.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
    RequestPath = "/wwwroot"
});


app.UseHttpsRedirection();
app.MapControllers();
app.Run();

// Pedro H Perpétuo CB3021688 & Igor Benites CB3021734