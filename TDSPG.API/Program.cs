
using Microsoft.OpenApi.Models;

namespace TDSPG.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //scoped -> pega o que tem pronto e altera
            //singleton -> reutiliza
            //transient -> tem pré definido e quando chamado, ele finaliza

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                    x.SwaggerDoc("v1", new OpenApiInfo
                    {
                            Title = builder.Configuration["Swagger:Title"],
                            Description = "Exemplo documentação swagger - aula advanced business with .NET",
                            Contact = new OpenApiContact
                            { 
                                    Name = "Leandro Correia",
                                    Email = "rm556203@fiap.com.br"
                            }
                    });
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
