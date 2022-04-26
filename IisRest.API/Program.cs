using IisRest.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.LoadSettingsFromConfiguration(builder.Configuration);
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureIdentityServer(builder.Configuration);
builder.Services.ConfigureAuth(builder.Configuration);
builder.Services.ConfigureAutoMapper(builder.Configuration);
builder.Services.ConfigureDependecyInjection(builder.Configuration);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
