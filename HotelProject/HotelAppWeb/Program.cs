global using HotelAppLibrary.HotelContext;
global using HotelAppLibrary.Services;
global using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string databaseType = builder.Configuration.GetValue<string>("DatabaseType").ToLower();

switch(databaseType)
{
    case "sql":

        builder.Services.AddDbContext<HotelAppDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("sql")));

        builder.Services.AddTransient<IHotelService, SqlService>();
        break;

    case "sqlite":

        //builder.Services.AddDbContext<HotelAppDBContext>(options =>
        //options.UseSqlite(builder.Configuration.GetConnectionString("sqlite")));
        break;
}


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
