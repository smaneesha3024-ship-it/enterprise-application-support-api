using Microsoft.EntityFrameworkCore;
using Support.API.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(connectionString!));
// Register services
builder.Services.AddControllers();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionFeature =
            context.Features.Get<
                Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();

        var logger = context.RequestServices
            .GetRequiredService<ILogger<Program>>();

        if (exceptionFeature?.Error != null)
        {
            logger.LogError(
                exceptionFeature.Error,
                "An unexpected application error occurred. Path: {Path}",
                context.Request.Path
            );
        }

        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(new
        {
            statusCode = 500,
            message = "An unexpected error occurred. Please contact application support."
        });
    });
});

// Configure HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// We are using HTTP for local development
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();