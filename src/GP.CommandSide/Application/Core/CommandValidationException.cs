using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GP.CommandSide.Application.Core
{
    public class CommandValidationException  :Exception
    {
        public CommandValidationException(ICommandWithValidation command, IEnumerable<ValidationFailure> messages)
        {
            _erros = messages.Select(r => r.ErrorMessage).ToList();
            _command = command;
        }

        private readonly List<string> _erros;
        private readonly ICommandWithValidation _command;

        public IReadOnlyCollection<string> Erros => _erros.AsReadOnly();
        public string CommandName => _command.GetType().Name;
    }
}
