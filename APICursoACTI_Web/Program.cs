using APICursoACTI_Application.Interfaces.Repositories;
using APICursoACTI_Application.Interfaces.Services;
using APICursoACTI_Application.Mappers;
using APICursoACTI_Application.Services;
using APICursoACTI_Infrastructure.Repositories;
using APICursoACTI_Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection de Application y Infrastructure
builder.Services.AddScoped(typeof(TaskItemMapper));
builder.Services.AddScoped<ITaskItemService, TaskItemService>();
//Repo
builder.Services.AddSingleton<ITaskItemRepository, InMemoryTaskItemRepository>();

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
//Proceso de manejo global de excepciones
app.UseMiddleware<GlobalExceptionMiddleware>();
app.Run();
