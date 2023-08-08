using System;
using FluentValidation;

namespace Notes.Application.Notes.Commands.CreateNode
{
    public class CreateNoteCommandValidator: AbstractValidator<CreateNodeCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(createNoteCommand =>
                createNoteCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand =>
                createNoteCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
