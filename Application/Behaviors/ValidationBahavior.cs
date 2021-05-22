using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Wrappers;
using FluentValidation;
using MediatR;

namespace Application.Behaviors
{
    public class ValidationBahavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBahavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // if you have validation setup for the request
            if (_validators.Any())
            {
                // create new validation context for the request
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                // validate for each task and return validationResult if all of them have commpleted
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                //get failures from ValidationResult 
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                // if failures 
                if (failures.Count != 0) throw new Exceptions.ValidationException(failures);
            }

            // return next the handle if you dont have a validation setup
            return await next();
        }
    }
}
