using Backend.Interface;
using Backend.Repository;
using BusinessLogic.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options => // Add CORS service
{
    options.AddPolicy("AllowAll", 
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add default connection string for the Web API controllers
builder.Services.AddDbContext<CertOnlineDbContext>(options =>
    options.UseSqlite(new SqliteConnectionStringBuilder
    {
        DataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database/Data.sqlite")
    }.ToString())
);

//dependencias/Serviços
builder.Services.AddScoped<ICertificationRepository, CertificationRepository>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IExamAttemptRepository, ExamAttemptRepository>();
builder.Services.AddScoped<IProfessionalRepository, ProfessionalsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // Use CORS

app.UseAuthorization();

app.MapControllers();

app.Run();