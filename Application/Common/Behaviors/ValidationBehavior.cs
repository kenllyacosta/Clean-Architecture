using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behaviors
{
    //Para validación de todos los modelos antes de que lleguen al manejador
    //Luego, registramos el comportamiento en Startup
    public class ValidationBehavior<RequestType, ResponseType> : IPipelineBehavior<RequestType, ResponseType> where RequestType : IRequest<ResponseType>
    {
        readonly IEnumerable<IValidator<RequestType>> Validators;
        public ValidationBehavior(IEnumerable<IValidator<RequestType>> validators)
        {
            Validators = validators;
        }

        public async Task<ResponseType> Handle(RequestType request, CancellationToken cancellationToken, RequestHandlerDelegate<ResponseType> next)
        {
            //En caso hayan validadores, pues valido
            if (Validators.Any())
            {
                var ValidationResults = await Task.WhenAll(
                    Validators.Select(validator => validator.ValidateAsync(request, cancellationToken)));

                var Failures = ValidationResults.SelectMany(
                    validationResult => validationResult.Errors).Where(failure => failure != null).ToList();

                if (Failures.Count() != 0)
                {
                    //Hay errores de validación
                    throw new ValidationException(Failures);
                }
            }

            return await next();
        }
    }
}
