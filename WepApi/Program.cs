using Apllication.Interfaces.Repository;
using Apllication.Interfaces.Services;
using Infrastructure.Configuration;
using Infrastructure.Services;
using Infrastructure.Services.Repository;
using Infrastructure.Services.Services;
using System.Reflection;
using WepApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
}
);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<IClientInterface, ClientService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductInterface, ProductService>();
builder.Services.AddScoped<IProviderInterface, ProviderService>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<CustomMiddlewares>();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
