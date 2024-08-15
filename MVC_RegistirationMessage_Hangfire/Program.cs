using Hangfire;
using Microsoft.EntityFrameworkCore;
using MVC_RegistirationMessage_Hangfire.Context;

var builder = WebApplication.CreateBuilder(args);

//DbContext Servisi:
string connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

//Hangfire Servisi:
builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(connectionString);

});
builder.Services.AddHangfireServer();




// Add services to the container.
builder.Services.AddControllersWithViews(); //MVC hizmeti.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHangfireDashboard(); //dashboard ekledik.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
