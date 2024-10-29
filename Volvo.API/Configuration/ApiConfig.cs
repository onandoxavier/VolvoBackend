using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Volvo.API.Data;
using Volvo.API.Utils.Middlewares;

namespace Volvo.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            #region dbContext
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContextPool<ApplicationDbContext>(optionsAction: options =>
                options.UseSqlServer(connectionString, o => o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "db")));
            #endregion

            #region ExceptionHandler
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            #endregion

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app)
        {
            #region dbContext
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            try
            {
                // Valida a existência do banco de dados e o cria se não existir
                dbContext.Database.EnsureCreated();

                // Aplica as migrations pendentes
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                // Lida com erros de conexão ou outros problemas
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Ocorreu um erro ao aplicar as migrations.");
            }
            #endregion

            #region ExceptionHandler
            app.UseExceptionHandler();
            #endregion
            return app;
        }
    }
}
