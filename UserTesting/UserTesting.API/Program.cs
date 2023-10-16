using UserTesting.DAL;
using UserTesting.BLL;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using UserTesting.DAL.Entities;
using UserTesting.DAL.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo() { Title = "UserTesting API", Version = "v1" });
	options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.Http,
		Scheme = JwtBearerDefaults.AuthenticationScheme
	});

	options.AddSecurityRequirement(new OpenApiSecurityRequirement()
	{
		{
			new OpenApiSecurityScheme()
			{
				Reference = new OpenApiReference()
				{
					Type = ReferenceType.SecurityScheme,
					Id = JwtBearerDefaults.AuthenticationScheme
				},
				Scheme = "Oauth2",
				Name = JwtBearerDefaults.AuthenticationScheme,
				In = ParameterLocation.Header
			},
			new List<string>()
		}
	});
});

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

// Add Identity core
builder.Services.AddIdentityCore<User>()
	.AddRoles<IdentityRole>()
	.AddTokenProvider<DataProtectorTokenProvider<User>>("UserTesting")
	.AddEntityFrameworkStores<UserTestingDbContext>()
	.AddDefaultTokenProviders();

// Add Tokent Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	options.TokenValidationParameters = new TokenValidationParameters()
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["Jwt:Issuer"],
		ValidAudience = builder.Configuration["Jwt:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(
			Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
	});

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
