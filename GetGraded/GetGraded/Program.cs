using GetGraded.BL.Services.Implementation;
using GetGraded.BL.Services.Interface;
using GetGraded.DAL.Repository.Implementation;
using GetGraded.DAL.Repository.Interface;
using GetGraded.Extensions;
using GetGraded.Migrations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddDbContext<GetGradedContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GetGradedDb")));

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
    pattern: "{controller=UserAccount}/{action=Login}/{id?}");

app.Run();
