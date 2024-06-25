using job_tasks.abstractions;
using job_tasks.bd.Connections;
using job_tasks.bd.Repositories;

using job_tasks.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BdContext>(
    Options=>{
        Options.UseMySQL(builder.Configuration.GetConnectionString(nameof(BdContext)), b=>b.MigrationsAssembly("job_tasks"));
    }
);
builder.Services.AddScoped<IClientRepository,ClientRepository>();
builder.Services.AddScoped<IFounderRepository,FounderRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IFounderService,FounderService>();
var app = builder.Build();

if(app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI(c=>{
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "job_tasks v1");
        c.RoutePrefix= string.Empty;
    }
    );
   
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();


app.Run();
