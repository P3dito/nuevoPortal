using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using practica3.Data;
using practica3.Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IServicioJsonPlaceholder, ServicioJsonPlaceholder>(client =>{client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");});

builder.Services.AddHttpClient<ServicioFeedback>(client =>{client.BaseAddress = new Uri("https://localhost:7234/"); });

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

if (env == "Development")
{
    // En desarrollo, usa URLs fijos con HTTPS y HTTP
    builder.WebHost.UseUrls("https://localhost:7234", "http://localhost:5204");
}
else
{
    // En producción (Render) solo HTTP en el puerto asignado por la variable de entorno PORT
    var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
    builder.WebHost.UseUrls($"http://*:{port}");
}



builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
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
app.MapRazorPages();

app.Run();
