var builder = WebApplication.CreateBuilder(args);

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors();

// Cached product list (performance optimization)
var products = new[]
{
    new
    {
        Id = 1,
        Name = "Laptop",
        Price = 1200.50,
        Stock = 25,
        Category = new { Id = 101, Name = "Electronics" }
    },
    new
    {
        Id = 2,
        Name = "Headphones",
        Price = 50.00,
        Stock = 100,
        Category = new { Id = 102, Name = "Accessories" }
    }
};

// Updated endpoint
app.MapGet("/api/productlist", () =>
{
    return Results.Ok(products);
});

app.Run();
