<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using formate.Context;
using formate.Services.IServices;
using formate.Services.Service;
=======
using formate.Context;
using formate.Services.IServices;
using formate.Services.Service;
using Microsoft.EntityFrameworkCore;
>>>>>>> 3ce4a15ebc9a49a45e8ada8785858236ebfc4c93

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

//Register services here
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
));

//inyeccion de dependencias

builder.Services.AddTransient<ICategoriaServices, CategoriaServices>();
builder.Services.AddTransient<IClienteServices, ClienteServices>();
builder.Services.AddTransient<IComentarioServices, ComentarioServices>();
builder.Services.AddTransient<IRolServices, RolServices>();
builder.Services.AddTransient<IUsuarioServices, UsuarioServices>();


builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<ApplicationDbContext>(opcions => opcions.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IClienteServices, ClienteService>();
builder.Services.AddTransient<IRolServices, RolServices>();
builder.Services.AddTransient<IUsuarioServices, UsuarioServices>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
