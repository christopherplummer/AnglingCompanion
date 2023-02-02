using AnglingCompanion.Database.Mongo;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true)
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.
builder.Services.AddScoped<IMongoClient, MongoClient>(_ =>
    new MongoClient(MongoClientSettings.FromConnectionString(configuration.GetConnectionString("MongoDatabaseConnectionString"))));
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<TripRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();