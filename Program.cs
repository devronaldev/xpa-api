using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using xpa_api.Contexts;
using DotNetEnv;
using Microsoft.IdentityModel.Tokens;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("alpha", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "XPrize Academy API",
        Version = "alpha",
        Description = "API desenvolvida para gest�o escolar e ambiente de aprendizado utilizando com .NET 9"
    });
});
builder.Services.AddOpenApi();

string? connectionString = Environment.GetEnvironmentVariable("SQLSERVER");
//TODO: Criar metódo para remover warning em nulidade.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


byte[] key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWTKEY"));
//TODO: Criar metódo para remover warning em nulidade.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, // Alterar em futura implementação
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateAudience = false
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/alpha/swagger.json", "Alpha 0.0.1");
    });
    
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            //SeedData.SeedDatabase(context); // Chamar o método de seed
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Ocorreu um erro ao popular o banco de dados.");
        }
    }
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
