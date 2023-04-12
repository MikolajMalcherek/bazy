using bazy.Controllers;
using bazy.Data;
using bazy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

static WebApplication InitializeApp(string[] args)
{
    ZawodnikDbContext _dbContext = new ZawodnikDbContext();
    ZawodnikSeeder seeder = new ZawodnikSeeder(_dbContext);
    var builder = WebApplication.CreateBuilder(args);
    ConfigureServices(builder);
    builder.Services.AddControllers();
    var app = builder.Build();
    Configure(app, seeder);
    return app;

}





static void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<ZawodnikDbContext>();
    builder.Services.AddScoped<ZawodnikController>();
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

app.Run();
