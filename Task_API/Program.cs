var builder = WebApplication.CreateBuilder(args);

int maxConnet = Convert.ToInt32(builder.Configuration["Settings:ParallelLimit"]);

var semaphore = new SemaphoreSlim(maxConnet);
// Add services to the container.

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

app.UseRouting();

app.Use(async (context, next) =>
{
    if (await semaphore.WaitAsync(maxConnet))
    {
        try
        {
            await next();
        }
        finally
        {
            semaphore.Release();
        }
    }
    else
    {
        context.Response.StatusCode = 503;
        await context.Response.WriteAsync("Service Unavailable");
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
