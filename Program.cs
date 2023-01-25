using Movies2Night.Client;
using Movies2Night.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("bestbuy");
// During the scope of my request // 
builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection conn = new MySqlConnection(connection);
    // Open before you can send a request to the DB //
    conn.Open();
    return conn;
});

// Adding Dependency Injection for my DB //
builder.Services.AddTransient<IMovieRepo, MovieRepo>();

// Dependency Injection for the API //
builder.Services.AddTransient<IMovieClient, MovieClient>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
