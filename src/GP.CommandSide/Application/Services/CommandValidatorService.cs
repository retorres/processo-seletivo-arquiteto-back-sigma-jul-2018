using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using GP.CommandSide.Application.Commands.MarcaCommands;
using GP.CommandSide.Application.Core;
using GP.CommandSide.Domain.Repositories;

namespace GP.CommandSide.Application.Services
{
    public class CommandValidatorService : ICommandValidatorService
    {
        private readonly IServiceProvider _serviceProvider;
        public CommandValidatorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ValidationResult Validate(ICommandWithValidation model)
        {
           var type = model.GetType();
            var genericClass = typeof(CommandValidator<>);
            var constructedClass = genericClass.MakeGenericType(type);
            var validator = _serviceProvider.GetService(constructedClass);

            if (validator == null)
            {
                return new ValidationResult();
            }

            var x = ((IValidator)validator).Validate(model);

            return x;
        }
    }
}
