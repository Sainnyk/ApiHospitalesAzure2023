using ApiHospitalesAzure2023.Data;
using ApiHospitalesAzure2023.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Hospitales Azure",
        Description = "Trabajando un lunes con Azure",
        Version = "v1",
        Contact = new OpenApiContact()
        {
            Name = "Alexandra Izquierdo Esteban",
            Email = "ialexandra.k9@gmail.com"
        }
    });
});


string connectionString = builder.Configuration.GetConnectionString("hospitalazure");
builder.Services.AddDbContext<HospitalContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<RepositoryHospital>();

var app = builder.Build();

app.UseSwagger();
//Vamos a indicar que la pagina inicial de nuestro servicio en Azure sera la documentacion
app.UseSwaggerUI(options =>{
    options.SwaggerEndpoint(
        url: "/swagger/v1/swagger.json", name: "Api v1"); //la url es siempre la misma, el name el que queramos
    options.RoutePrefix = ""; // url swagger
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
