using Microsoft.EntityFrameworkCore;
using WitsXMxic.Models.DBModels;
using WitsXMxic.Services.Implement;
using WitsXMxic.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region DB
var dbConnectionString = builder.Configuration.GetConnectionString("WitsXMxic");
builder.Services.AddDbContext<WitsXMxicContext>(options =>
    options.UseSqlServer(dbConnectionString));
#endregion

#region ²K¥[ªA°È
builder.Services.AddScoped<ITeamService, TeamService>();
#endregion

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
    pattern: "{controller=Team}/{action=Index}/{id?}");

app.Run();
