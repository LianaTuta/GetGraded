using GetGraded.Extensions;
using GetGraded.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using GetGraded.BL.UserProfileStrategy.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().
    AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    // Add any other JSON serialization options as needed
}); ;
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.RegisterUserProfileStrategy();
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
    pattern: "{controller=UserAccount}/{action=SignUp}/{id?}");

app.Run();
