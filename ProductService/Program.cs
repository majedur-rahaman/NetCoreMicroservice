using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductService.Data;
using ProductService.IRepository;
using ProductService.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductDBContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ProductDB")
    )
);
//DI
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProductDBContext>();

    // Drop and recreate database
    dbContext.Database.EnsureDeleted();
    dbContext.Database.Migrate(); // applies all migrations
}
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
