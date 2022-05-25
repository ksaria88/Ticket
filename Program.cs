using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AtencionCliente.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AtencionClienteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AtencionClienteContext") ?? throw new InvalidOperationException("Connection string 'AtencionClienteContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
