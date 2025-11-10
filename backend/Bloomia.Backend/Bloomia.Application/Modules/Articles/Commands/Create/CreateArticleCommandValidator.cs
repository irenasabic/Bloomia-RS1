using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Articles.Commands.Create
{
    public sealed class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .Must(x => x != "string")
                .WithMessage("Title cannot be empty or default value 'string'.");
                    
            RuleFor(x => x.Content)
                .NotEmpty()
                .Must(x => x != "string")
                .WithMessage("Content cannot be empty or default value 'string'.");
        }
    }
}
