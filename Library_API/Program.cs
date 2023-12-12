using Library_API.BLL.Interfaces;
using Library_API.BLL.Mapping;
using Library_API.BLL.Services;
using Library_API.DAL.EFUnitOfWork;
using Library_API.DAL.Interfaces;
using Library_API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(BookMapper));

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
