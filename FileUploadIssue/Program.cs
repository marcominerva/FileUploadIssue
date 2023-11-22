var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.MapPost("/api/upload", (IFormFile file) =>
{
    return TypedResults.Ok(file.FileName);
})
.DisableAntiforgery();

app.MapPost("/api/upload_with_openapi", (IFormFile file) =>
{
    return TypedResults.Ok(file.FileName);
})
.DisableAntiforgery()
.WithOpenApi();

app.Run();
