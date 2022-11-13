using AdvancePal.Server.Model;

using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdvancePalContext>(
	opt => opt.UseSqlite(builder.Configuration.GetConnectionString("default"))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
	swagger.SwaggerDoc("v1", new(){ Title = "AdvancePal API", Version = "v1" });
	swagger.CustomOperationIds(e =>
	{
		var method = e.HttpMethod ?? "";

		var operation = e.ActionDescriptor.RouteValues["controller"];

		if (
			e.ActionDescriptor is ControllerActionDescriptor descriptor &&
			!descriptor.ActionName.Equals(method, StringComparison.OrdinalIgnoreCase)
		)
		{
			operation = descriptor.ActionName;
		}

		var prefix = method switch
		{
			"POST" => "create",
			"PUT" => "update",
			"DELETE" => "delete",
			"GET" when (e.ParameterDescriptions.Count == 0) => "list",
			var m => m.ToLowerInvariant(),
		};

		return $"{prefix}{operation}";
	});
});

builder.Services.AddResponseCompression();

var app = builder.Build();

app.UseResponseCompression();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<AdvancePalContext>();
	await db.Database.MigrateAsync();
}

app.Run();
