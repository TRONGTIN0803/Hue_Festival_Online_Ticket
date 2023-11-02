using Hue_Festival_Online_Ticket.Context;
using Hue_Festival_Online_Ticket.IService;
using Hue_Festival_Online_Ticket.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conect db
builder.Services.AddDbContext<Hue_Festival_Context>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("strConnect"));

}

);
//register service
builder.Services.AddScoped<IChuongtrinhService, ChuongtrinhService>();
builder.Services.AddScoped<IDiadiemService, DiadiemService>();
builder.Services.AddScoped<ILichdienService, LichdienService>();
builder.Services.AddScoped<ITintucService, TintucService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IQuanlyService, QuanlyService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
