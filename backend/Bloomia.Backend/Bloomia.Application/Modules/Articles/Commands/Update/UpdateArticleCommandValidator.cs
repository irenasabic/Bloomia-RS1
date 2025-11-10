using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Articles.Commands.Update
{
    public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);

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
