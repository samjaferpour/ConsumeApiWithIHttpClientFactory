using ConsumeApiWithIHttpClientFactory.Dtos.Setting;
using ConsumeApiWithIHttpClientFactory.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// fill options
builder.Services.AddOptions<SiteSetting>().Bind(builder.Configuration.GetSection("SchoolConfig"));

// IocExtensions
builder.Services.AddHttpClientFactory();
builder.Services.AddCustomServices();






var app = builder.Build();

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
