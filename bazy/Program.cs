using bazy.Controllers;
using bazy.Data;
using bazy;
using Microsoft.EntityFrameworkCore;
using bazy.Services.Interfaces;
using bazy.Services;
using bazy.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();





static void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<ZawodnikDbContext>();
    builder.Services.AddScoped<ZawodnikController>();
    builder.Services.AddScoped<IZawodnikService, ZawodnikService>();
    builder.Services.AddScoped<HttpClient>();
    builder.Services.AddHttpClient<IZawodnikService, ZawodnikService>(c =>
    c.BaseAddress = new Uri("https://localhost:7163/"));
    // rejestrujemy jeszcze serwis seedujacy
    builder.Services.AddScoped<ZawodnikSeeder>();
}


// Metoda Configure b�dzie konfigurowa� wszystkie niezb�dne metody przep�ywu, przez kt�re musi przej�� zapytanie z API przed zwr�ceniem odpowiedzi
static void Configure(WebApplication app, ZawodnikSeeder Seeder)
{
    Console.WriteLine("WPISUJE");
    Seeder.Seed();

    // Powoduje to, �e je�li klient API wy�le zapytanie bez protoko�u https, to jego zapytanie automatycznie zostanie przekierowane na adres
    // z protoko�em https
    app.UseHttpsRedirection();
    app.UseRouting();
}

ZawodnikDbContext _dbContext = new ZawodnikDbContext();
ZawodnikSeeder seeder = new ZawodnikSeeder(_dbContext);
ConfigureServices(builder);


var app = builder.Build();

Configure(app, seeder);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

LocationEndpointsConfig.AddEndpoints(app);

app.Run();
