using Microsoft.EntityFrameworkCore;
using Vdmt_Lesson11.Models;
using vudominnhthanh_2310900099.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("Vudominhthanh2310900099Context") ?? "Server=.\\VUDOMINHTHANH;Database=vudominhthanh_2310900099;uid=sa;pwd=1234;MultipleActiveResultSets=True;TrustServerCertificate=True";
builder.Services.AddDbContext<Vudominhthanh2310900099Context> (options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/VdmtHome/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=VdmtHome}/{action=VdmtIndex}/{VdmtId?}");

app.Run();
