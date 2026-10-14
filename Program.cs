var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseExceptionHandler();

if(!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();
app.UseStatusCodePages();

app.MapGet("/", () => Results.Ok(new { message = "pong" }))
    .WithName("Ping")
    .WithDescription("Returns a pong response to indicate the service is running.");

app.MapFallback(() => Results.Ok(new { message = "pong" }))
    .WithName("Fallback")
    .WithDescription("Handles requests to undefined routes and returns a 404 Not Found response.");

app.Run();
