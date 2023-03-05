using Application.Activities;
using Application.BaseGetData.UniteOfWork;
using Application.Core;
using Application.Core.MiddleWare;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//contect with database
builder.Services.AddDbContext<DataContext>(op =>
{
    op.UseSqlite(builder.Configuration.GetConnectionString("DataConnect"));
});
// signe register 
builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();

// use Meditor
builder.Services.AddMediatR(typeof(List.Handler).Assembly);
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);


//middleware customize
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
