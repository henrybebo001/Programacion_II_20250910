using Microsoft.EntityFrameworkCore;
using Web.Domain.Repository;
using AppDb = Web.Infrastructure.Context.SystemAdminApiContext;
using Web.Infrastructure.Repositories;
using Web.Application.Interfaces.Reposity;
using Web.Application.Services.AdminService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAdminServices, AdminService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddDbContext<AppDb>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Web.Infrastructure")
    ));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API v1");
    c.RoutePrefix = string.Empty; // Abre Swagger al iniciar en "/"
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();