using BeerHubSystem.Application;
using BeerHubSystem.Application.Exceptions;
using BeerHubSystem.Application.Features.Commands.RequestQuote;
using BeerHubSystem.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BeerHubSystem.API
{
    public static class SetupExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddApplicationServices();
            services.AddInfrastructureServices(configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();

            // Register validators
            services.AddTransient<IValidator<RequestQuoteCommand>, RequestQuoteCommandValidator>();

            return builder;
        }

        public static WebApplication ConfigurePipeline(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}
