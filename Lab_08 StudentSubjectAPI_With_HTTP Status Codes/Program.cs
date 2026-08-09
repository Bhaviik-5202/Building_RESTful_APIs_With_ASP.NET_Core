
using Scalar.AspNetCore;

namespace Lab_08_StudentSubjectAPI_With_HTTP_Status_Codes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                // Map the Scalar UI that exposes a browsable API reference at /scalar
                app.MapScalarApiReference();
            }

            // Provide a simple root redirect to the Scalar UI for convenience
            app.MapGet("/", () => Results.Redirect("/scalar"));

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
