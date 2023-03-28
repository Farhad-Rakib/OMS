using AutoMapper;
using Infrastructure.Data.Repository;
using Infrastructure.Dbcontext;
using OMS.Application.Repositories;
using OMS.Application.Service;
using OMS.Application.Services;
using OMS.Server.Utilities.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();



//Add dependency lifetime
#region Repositories

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IWindowRepository, WindowRepository>();
builder.Services.AddScoped<ISubElementRepository, SubElementRepository>();

#endregion

#region Services
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IWindowService, WindowService>();
builder.Services.AddScoped<ISubElementService, SubElementService>();

#endregion

#region Utilities
builder.Services.AddScoped<ApplicationDbContext>();
#endregion

//Add auto mapper config
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.UseSwagger();

// This middleware serves the Swagger documentation UI
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order ManagementSystem By Intus Windows V1");
    c.RoutePrefix = "oms/apis";
    c.DocumentTitle = "Order Management Service by Intus";
});


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
