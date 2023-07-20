using MusicaApi.Models;
using MusicaApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.Configure<MusicaDatabaseSettings>(
    builder.Configuration.GetSection("MusicaDatabase"));

builder.Services.AddSingleton<CancionService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
    {

        options.AddPolicy("PoliticaCors",
            policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();


app.UseCors("PoliticaCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
