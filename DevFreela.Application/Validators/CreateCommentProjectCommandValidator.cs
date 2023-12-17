using DevFreela.Application.Commands.CreateCommentProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateCommentProjectCommandValidator : AbstractValidator<CreateCommentProjectCommand>
    {
        public CreateCommentProjectCommandValidator()
        {
            RuleFor(c => c.Content)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de comentário é de 255 caracteres.");
        }
    }
}
