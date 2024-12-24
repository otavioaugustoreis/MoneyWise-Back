using MoneyWise.Data;
using MoneyWise.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddConectionBD(builder.Configuration);

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
        throw new Exception($"Erro ao executar o seeding: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
