var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.AddRazorPages();

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
app.MapRazorPages();

app.MapGet("/", () => Results.Ok(new { message = "pong" }))
    .WithName("Ping")
    .WithDescription("Returns a pong response to indicate the service is running.");

app.Run();
