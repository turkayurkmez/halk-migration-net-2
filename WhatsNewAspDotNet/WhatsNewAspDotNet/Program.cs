using WhatsNewAspDotNet.Services;

var builder = WebApplication.CreateBuilder(args);

//var builder = WebApplication.CreateBuilder(new WebApplicationOptions
//{
//    WebRootPath = "myspecialwwwroot",
//    Args = args,
//    EnvironmentName = Environments.Production
//});


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IProductService, OzProductService>();
//builder.Services.AddSession();

var connectionString = builder.Configuration.GetConnectionString("db");

builder.Logging.AddConsole();

var app = builder.Build();

app.Logger.LogInformation($"konfigürasyon dosyasında yazan değer: {connectionString}");


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
