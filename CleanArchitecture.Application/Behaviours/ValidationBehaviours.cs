using FluentValidation;
using MediatR;
using ValidationException = CleanArchitecture.Application.Exception.ValidationException;

namespace CleanArchitecture.Application.Behaviours
{
    public class ValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest: IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviours(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                //La siguiente linea no solo es buscar todas las validaciones de la aplicación, si no tambien ejecutarlas
                //No las ejecuta dentro del método final de la aplicación, si no que las va a ejecutar en el tubo
                //Antes de que llegue al interior, si existe algun error se detiene el flujo del request
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                // lo siguiente retorna un conjunto de errores
                var failures= validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if(failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
