using Microsoft.EntityFrameworkCore;
using ProjectShifts.Data;
using SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddDbContext<ProjectShiftsContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("mySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.2")));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Index}");


app.UseEndpoints(endpoints =>
{
  
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapHub<MiHub>("/miHub"); // Asigna una ruta al Hub
});


app.Run();
