using API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAuthentication("Bearer")
	.AddIdentityServerAuthentication("Bearer", options =>
	{
		options.Authority = "https://localhost:5443";
		options.ApiName = "CoffeeAPI";
	});

builder.Services.AddScoped<CoffeeShopService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
