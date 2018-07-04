using FluentValidation.Results;
using GP.CommandSide.Application.Core;

namespace GP.CommandSide.Application.Services
{
    public interface ICommandValidatorService
    {
        ValidationResult Validate(ICommandWithValidation model);
    }
}
