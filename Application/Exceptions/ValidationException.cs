﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException():base("validation failed")
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
