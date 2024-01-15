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
//builder.Services.AddSingleton<IProductService, OzProductService>();
//builder.Services.AddTransient<IProductService, OzProductService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//builder.Services.AddSession();

var connectionString = builder.Configuration.GetConnectionString("db");

builder.Logging.AddConsole();

var app = builder.Build();

app.Logger.LogInformation($"konfigürasyon dosyasında yazan değer: {connectionString}");
//Yukarıda, IoC içerisine eklediğiniz (kaydettiğiniz) OzProductService instance'ına burada ihtiyaç duyarsanız nasıl elde edersiniz?
IProductService productService = app.Services.GetRequiredService<IProductService>();
app.Logger.LogInformation($"IoC'ye eklenen instance içindeki değerler: {string.Join(",", productService.GetProducts().AsEnumerable().Select(p => p.Name))}");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //eğer entity framework (migration) sırasında hata olursa; aşağıdaki middleware'ler devreye girecek
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();

    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapGet("/test", () => "Burasi test sayfasidir.");


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
