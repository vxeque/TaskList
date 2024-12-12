using Microsoft.EntityFrameworkCore;
using TaskListCRUD.Business;
using TaskListCRUD.Business.Services;
using TaskListCRUD.DataAccess; 

var builder = WebApplication.CreateBuilder(args);

// Registrar DbContext
builder.Services.AddDbContext<TaskListContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar TaskListRepository
builder.Services.AddScoped<TaskListRepository>();

// Registrar el servicio de TaskList
builder.Services.AddScoped<TaskListService>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

//app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapRazorPages();

app.Run();
