using DAL;
using DAL.Interface;
using MvcArcheryWebshop.Models;
using WebshopClassLibrary;
using WebshopClassLibrary.Interface;
using WebshopClassLibrary.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductDAL, ProductDAL>(); //IMPORTANT WHEN ADDING PAGES!!!! IN PROGRAM.CS, NOT IN STARTUP.CS
builder.Services.AddScoped<ICategoryDAL, CategoryDAL>();
builder.Services.AddScoped<ICartDAL, CartDAL>();
builder.Services.AddScoped<ICartLogic, CartLogic>();
builder.Services.AddScoped<ProductCollection>();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation(); //addrazorruntime makes it so edits are possible by saving the file while program is running
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default", //makes it so that the default view user home controller and the index action
    pattern: "{controller=Home}/{action=Index}/{id?}"); //id is optional, controller and action are not

app.Run();