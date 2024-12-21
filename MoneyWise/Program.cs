using MoneyWise.Data;
using MoneyWise.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string conecction = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddConectionBD(conecction);

builder.Services.AddDIPScoppedClasse();
builder.Services.AddDIPSingletonClasse();
builder.Services.AddMapperStartup();
builder.Services.AddCofigurationJson();

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var seedingService = services.GetRequiredService<SeedingServiceData>();
        seedingService.Seeding(); // Executa o método de seeding
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao executar o seeding: {ex.Message}");
    }
}

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
