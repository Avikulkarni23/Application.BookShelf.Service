using Application.BookShelf.Infrastructure;
using Application.BookShelf.Repository;
using Application.BookShelf.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<BookShelfDbContext>();
builder.Services.AddTransient<IBookRepo, BookRepo>();
builder.Services.AddTransient<IBookService, BookService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.MapControllers();

/*app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action}",
    defaults: "api/Book/GetAllBooks",

    name: "Purcahse",
    pattern: "api/{controller}/{action}",
    defaults: "api/Purchase/GetReceipt",
    
    

    );*/

app.Run();
