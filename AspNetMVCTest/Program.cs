using System.Text;

using ApplicationCore.Implementations;
using ApplicationCore.Interfaces;

using DAL.Entities;
using DAL.Implementations;
using DAL.Interfaces;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using Representation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var connectionOptions = builder.Configuration.GetConnectionString("MSSQL");

builder.Services.AddSwaggerGen(c =>
{
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement {
		{
			new OpenApiSecurityScheme {
				Reference = new OpenApiReference {
					Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
				}
			},
			new string[] {}
		}
	});
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			// указывает, будет ли валидироваться издатель при валидации токена
			ValidateIssuer = true,
			// строка, представляющая издателя
			ValidIssuer = AuthOptions.ISSUER,
			// будет ли валидироваться потребитель токена
			ValidateAudience = true,
			// установка потребителя токена
			ValidAudience = AuthOptions.AUDIENCE,
			// будет ли валидироваться время существования
			ValidateLifetime = true,
			// установка ключа безопасности
			IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
			// валидация ключа безопасности
			ValidateIssuerSigningKey = true,
		};
	});
builder.Services.AddAuthorization(
   options =>
		options.AddPolicy("Only for admun", policy => policy.RequireClaim("role", "admin"))
);

builder.Services.AddDbContext<DataDbContext>(options => options.UseSqlServer(connectionOptions));

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddScoped<IRepository<TaskEntity>, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Debug}/{action=Swagger}");


app.Run();




public class AuthOptions
{
	public const string ISSUER = "MyAuthServer"; // издатель токена
	public const string AUDIENCE = "MyAuthClient"; // потребитель токена
	const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
	public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
		new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}