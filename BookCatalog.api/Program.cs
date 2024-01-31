using BookCatalog.Domain.Contracts;
using BookCatalog.Infrastructure.Database.Contexts;
using BookCatalog.Infrastructure.Database.Repositories;
using EntityFrameworkCore.UseRowNumberForPaging;
using MediatR;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Using UseInMemory
//builder.Services.AddDbContext<BookDBContext>(options =>
//    options.UseInMemoryDatabase("BooksDB")
//);

//Using SQL Server 2008 with migrations
builder.Services.AddDbContext<BookDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"),
        b =>
        {
            b.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
            b.UseRowNumberForPaging();
        });
});

builder.Services.AddAutoMapper(typeof(BookCatalog.Application._ForAppServiceAssembyLoadOnly).Assembly);
//builder.Services.AddMediatR(cfg =>
//    cfg.RegisterServicesFromAssemblies(typeof(BookCatalog.Application._ForAppServiceAssembyLoadOnly).Assembly));
builder.Services.AddMediatR(typeof(BookCatalog.Application._ForAppServiceAssembyLoadOnly).Assembly);

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
