using CleanArchitecture.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Hacen automaticamente la inyeccion de las clases que implementan sus interfaces en el proyecto.


            //Registramos el asemmbly de la libreria que me permite hacer mapping de las clases de origen a una clase destino
            //Automaticamente lle todas las clases que esten heredando, implementando las interfaces del automaper y las va a inyectar
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //busca todas las clases del proyecto application que esten referenciando al abstract validation
            //Automaticamente va a inyectar, va a instanciar, crear los objetos para que esa validación sea posible dentro del proyecto.
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            //agregaremos un addtramsient de validación y tambien de las excepciones
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviours<,>));
            return services;
        }
    }
}
