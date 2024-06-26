var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.MapControllers();   
app.UseRouting();   
app.UseStaticFiles();
app.Run();
