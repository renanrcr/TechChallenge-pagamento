using Domain.Adapters;
using Infrastructure;
using Application;
using API.Configurations;
using Domain.Configuration;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
builder.Services.Configure<SettingsMercadoPago>(configuration.GetSection("MercadoPago"));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddInfraModule();
builder.Services.AddApplicationModule();

builder.Services.AddSwaggerGenConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechChallenge v1"));
}

app.UseReDoc(c =>
{
    c.DocumentTitle = "API Documentação";
    c.SpecUrl = "/swagger/v1/swagger.json";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPost("/webhook", async (HttpContext context, IReceiveWebhook receiveWebook) =>
{
    using StreamReader stream = new StreamReader(context.Request.Body);
    return await receiveWebook.ProcessRequest(await stream.ReadToEndAsync());
});

app.Run();