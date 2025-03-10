
using Serilog;

namespace LoggingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        

            builder.Services.AddLogging(loggingBuilder =>
            {
                // Get the builder's configuration from your Program 
                // Reads the appsettings.json file
                ConfigurationManager configurationManager = builder.Configuration;

                // Create a new LoggerConfiguration so that you can tell 
                // it to get its configuration from your appsettings.json file
                var logger = new LoggerConfiguration()
                    .ReadFrom
                    .Configuration(configurationManager)

                    // Finally create the logger which will be used
                    .CreateLogger();

                // Adds serilog to the logging providers
                loggingBuilder.AddSerilog(logger);
            });

            var app = builder.Build();

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
        }      
    }
}