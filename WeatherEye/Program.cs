using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WeatherEye.Interfaces;
using WeatherEye.Models;
using WeatherEye.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddTransient<IRainSensor, RainSensorService>();

builder.Services.AddTransient<ILatestSensorData, LatestSensorDataService>();
builder.Services.AddTransient<ISensorsDataGatherer, SensorsDataGathererService>();
builder.Services.AddTransient<ISensors, SensorsDataService>();
// Add services to the container.
builder.Services.AddControllersWithViews();



/*builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WeatherEye", Version = "v1" });
});*/

var connectionString = builder.Configuration.GetConnectionString("Connection");

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/*app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherEye v1"));*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
