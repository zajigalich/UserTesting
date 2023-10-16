using UserTesting.DAL;
using UserTesting.BLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add service for caching
builder.Services.AddOutputCache(options =>
{
	options.AddBasePolicy(builder =>
		builder
		.Tag("tag-all")
		.Expire(TimeSpan.FromSeconds(60)));
	options.AddBasePolicy(builder =>
		builder.With(r => r.HttpContext.Request.Path.StartsWithSegments("/api/tests"))
		.Tag("tag-test")
		.Expire(TimeSpan.FromSeconds(60)));
});

// Configure services from class libs (adding them to container)
builder.Services.ConfigureBusinessLogicLayerServices();
builder.Services.ConfigureDataAccessLayerServices(builder.Configuration.GetConnectionString("UserTestingConnectionString")!);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors();
app.UseOutputCache();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
