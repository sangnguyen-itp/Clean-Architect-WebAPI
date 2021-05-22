using Application.Utils;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.DOB)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .Must(IsGreaterThan1970).WithMessage("{PropertyName} is greater than 1/1/1970.");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

        }

        private bool IsGreaterThan1970(long DOB)
        {
            var helper = new DatetimeHelper();
            return DOB >= helper.GetDefaultUnixTime();
        }
    }
}
