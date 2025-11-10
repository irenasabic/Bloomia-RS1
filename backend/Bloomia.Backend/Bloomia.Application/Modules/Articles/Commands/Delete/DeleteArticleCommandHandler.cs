using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Articles.Commands.Delete
{
    public class DeleteArticleCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
    : IRequestHandler<DeleteArticleCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken ct)
        {
            if (currentUser.UserId == null)
                throw new BloomiaBusinessRuleException("NOT_LOGGED_IN", "You have to be logged in.");

            if (!currentUser.IsAdmin)
                throw new BloomiaBusinessRuleException("USER_NOT_AUTH", "Only admins can delete articles.");

            var article = await context.Articles
                .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

            if (article == null)
                throw new BloomiaNotFoundException($"Article with Id {request.Id} not found.");

            article.IsDeleted = true; //soft delete
            await context.SaveChangesAsync(ct);

            return Unit.Value;
        }
    }
}
