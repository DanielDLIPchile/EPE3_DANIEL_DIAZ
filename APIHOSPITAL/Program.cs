using APIHOSPITAL.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

String ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
//DI
// Configura el contexto de la base de datos con la cadena de conexion
builder.Services.AddDbContext<APIHOSPITALDbContext>(options =>
{
    options.UseMySQL(ConnectionString);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
