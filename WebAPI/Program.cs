using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var MyAllowSpecificOrigins = "http://localhost:4200";
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddRazorPages();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
            {
                policy.WithOrigins(MyAllowSpecificOrigins)
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .WithMethods("PUT", "DELETE", "GET");
            });
        });

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });

        ServiceTool.Create(builder.Services);

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
        {
            builder.RegisterModule(new AutofacBusinessModule());
        });

        builder.Services.AddDependencyResolvers(new ICoreModule[]
        {
            new CoreModule()
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.ConfigureCustomExceptionMiddleware();
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseCors(MyAllowSpecificOrigins);
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
