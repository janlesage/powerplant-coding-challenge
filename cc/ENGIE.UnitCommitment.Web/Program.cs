var builder = WebApplication.CreateBuilder(args);

// Use port 8888 as stated in the acceptance criteria
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(
        port: 8888, 
        configure: listenOptions => listenOptions.UseHttps());
});

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
