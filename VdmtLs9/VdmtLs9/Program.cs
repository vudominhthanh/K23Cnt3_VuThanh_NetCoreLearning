using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/VdmtHome/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
var connectionString = builder.Configuration.GetConnectionString("BookStoreContext") ?? "Server=.\\VUDOMINHTHANH;Database=BookStore;uid=sa;pwd=1234;MultipleActiveResultSets=True;TrustServerCertificate=True";
builder.Services.AddDbContext<VdmtLs9.Models.BookStoreContext>(options =>
    options.UseSqlServer(connectionString));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=VdmtHome}/{action=Vdmt3Index}/{id?}");

app.Run();
