var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//builder.Services.AddScoped<IProductDAL, ProductDAL>(); //IMPORTANT WHEN ADDING PAGES!!!! IN PROGRAM.CS, NOT IN STARTUP.CS
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation(); //addrazorruntime makes it so edits are possible by saving the file while program is running
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

app.UseSession();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default", //makes it so that the default view user home controller and the index action
    pattern: "{controller=Home}/{action=Index}/{id?}"); //id is optional, controller and action are not

app.Run();