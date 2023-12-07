using GMPay.Api.Middlewares;
using GMPay.Data.Model;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GMPayContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("GMPayConstr"),
                                 sqlServerOptionsAction: sqlOptions =>
                                 {
                                     sqlOptions.EnableRetryOnFailure(
                                                 maxRetryCount: 3,
                                                 maxRetryDelay: TimeSpan.FromSeconds(30),
                                                 errorNumbersToAdd: null);
                                 })
                                , ServiceLifetime.Transient
   );
builder.Services.AddHttpClient();
builder.Services.ConfigureService();

var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<GMPayContext>();
        context.Database.Migrate();
    }


    app.UseCors(
         options => options.SetIsOriginAllowed(x => _ = true)
         .AllowAnyMethod()
         .AllowAnyHeader()
         .AllowCredentials()
     );
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
