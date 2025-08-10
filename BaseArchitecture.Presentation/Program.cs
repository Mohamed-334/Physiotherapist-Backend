using BaseArchitecture.Core;
using BaseArchitecture.Core.Shared.CustomMiddleware;
using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Domain.Shared.JwtModels;
using BaseArchitecture.Infrastructure;
using BaseArchitecture.Infrastructure.Context;
using BaseArchitecture.Infrastructure.Seeder;
using BaseArchitecture.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Text;

namespace BaseArchitecture.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            #region Swagger Config
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Base Project",
                    Version = "v1",
                    Description = "API Documentation for Base Project"
                });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securityScheme);
                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        securityScheme,
                        new string[] {}
                    }
                };
                c.AddSecurityRequirement(securityRequirement);
            });

            #endregion

            #region Context Registration

            // Register the DbContext with the connection string from configuration
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("BaseArchitecture"));
            });

            #endregion

            #region Jwt Authentication Config
            var jwtSettings = new JwtSettings();
            builder.Configuration.GetSection("JwtSettings").Bind(jwtSettings);
            builder.Services.AddSingleton(jwtSettings);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    ValidAudience = jwtSettings.Audience,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidateLifetime = jwtSettings.ValidateLifeTime,
                    ClockSkew = TimeSpan.Zero
                };

                // إضافة events للـ JWT Bearer لضمان إرجاع proper status codes
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        // منع الـ default challenge behavior
                        context.HandleResponse();

                        // إرجاع 401 بدلاً من redirect
                        if (!context.Response.HasStarted)
                        {
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            return context.Response.WriteAsync("{\"error\": \"Unauthorized\", \"message\": \"Valid JWT token is required\"}");
                        }
                        return Task.CompletedTask;
                    },
                    OnForbidden = context =>
                    {
                        // إرجاع 403 بدلاً من redirect
                        if (!context.Response.HasStarted)
                        {
                            context.Response.StatusCode = 403;
                            context.Response.ContentType = "application/json";
                            return context.Response.WriteAsync("{\"error\": \"Forbidden\", \"message\": \"You don't have permission to access this resource\"}");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            #endregion

            #region Identity Config
            builder.Services.AddIdentity<User, Role>(options =>
            {
                // إعدادات الـ Identity العامة
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<AppDbContext>();

            // تكوين الـ Identity للـ API - منع الـ redirects
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    // بدلاً من redirect، ارجع 401
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";
                    return context.Response.WriteAsync("{\"error\": \"Unauthorized\", \"message\": \"Authentication required\"}");
                };

                options.Events.OnRedirectToAccessDenied = context =>
                {
                    // بدلاً من redirect، ارجع 403
                    context.Response.StatusCode = 403;
                    context.Response.ContentType = "application/json";
                    return context.Response.WriteAsync("{\"error\": \"Forbidden\", \"message\": \"Access denied\"}");
                };
            });
            #endregion

            #region Dependency Injection
            builder.Services.AddInfrastructureDependencies()
                .AddServiceDependencies()
                .AddCoreDependencies();
            #endregion

            #region Localization configuration
            builder.Services.AddControllersWithViews();
            builder.Services.AddLocalization(opt => opt.ResourcesPath = "");

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("de-DE"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("ar-EG")
                };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            #endregion

            #region AllowCORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: builder.Configuration.GetSection("CorsConfig")["CorsConfigName"]!,
                    policy =>
                    {
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                        policy.AllowAnyOrigin();
                    });
            });
            #endregion

            var app = builder.Build();

            #region Seeders
            using (var scope = app.Services.CreateScope())
            {
                var Users = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var Roles = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                await RoleSeeder.SeedAsync(Roles);
                await UserSeeder.SeedAsync(Users);
            }
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Base Architecture v1"));
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Base Architecture v1"));
            }

            #region Localization middleware
            var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOptions!.Value);
            #endregion

            app.Use(async (context, next) =>
            {
                Console.WriteLine($"➡️ Request Path: {context.Request.Path}");
                await next.Invoke();
                Console.WriteLine($"⬅️ Response Status: {context.Response.StatusCode}");
            });

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHttpsRedirection();

            app.UseCors(builder.Configuration.GetSection("CorsConfig")["CorsConfigName"]!);

            // ترتيب الـ middleware مهم جداً
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}