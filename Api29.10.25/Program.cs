
using Api29._10._25.Behaviors;
using Api29._10._25.CQRS.Command;
using MyMediator.Extension;
using MyMediator.Interfaces;
using MyMediator.Types;
using System.Reflection;

namespace Api29._10._25
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

            builder.Services.AddSingleton<IMediator, Mediator>();

            builder.Services.AddMediatorHandlers(Assembly.GetExecutingAssembly());


            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ClientInfoBehavior<,>));

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UseBehavior<,>));

            builder.Services.AddTransient<IValidator<RegistreUserCommand>, UserCommandVaildator>();
            builder.Services.AddTransient<IValidator<NewOrderCommand>, OrderCommandValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
