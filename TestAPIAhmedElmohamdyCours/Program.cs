using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Small_e_commers.Data;
using Small_e_commers.Hubs;
using TestAPIAhmedElmohamdyCours.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option => option.UseLazyLoadingProxies()
				.UseSqlServer(builder.Configuration.GetConnectionString("Myconnect")));

builder.Services.AddIdentity<AppUserDbContext , IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


//////////////////////////////////  CROS  /////////////////////////////////////
builder.Services.AddCors(cors =>
{
	cors.AddPolicy("MyPolicy", corsPolicyBuilder =>
	{
		corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
	});

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<ItemHub>("/signalhub");

app.Run();
