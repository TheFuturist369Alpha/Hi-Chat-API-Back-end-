using Hubs;

using Microsoft.Extensions.Configuration;


using Services.ChatService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<ChatServe>();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(build =>
    {
        build.WithOrigins("http://localhost:4200");
        build.AllowAnyHeader();
        build.WithMethods("GET", "POST", "PUT", "DELETE");
        build.AllowCredentials();
       
    });

});



var app = builder.Build();

//app.UseCors(cors => cors.AllowAnyHeader()
//.AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:4200"));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseCors();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/chat");
app.Run();

