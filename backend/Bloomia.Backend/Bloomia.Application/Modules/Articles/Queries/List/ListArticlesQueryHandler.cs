using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Articles.Queries.List
{
    public class ListArticlesQueryHandler(IAppDbContext context)
        : IRequestHandler<ListArticlesQuery, PageResult<ListArticlesQueryDto>>
    {
        public async Task<PageResult<ListArticlesQueryDto>> Handle(ListArticlesQuery request, CancellationToken ct)
        {
            var query = context.Articles
                .Include(x => x.Admin)
                .ThenInclude(admin => admin.User)
                .Where(a => !a.IsDeleted)
                .AsQueryable();

            //pretraga po naslovu
            if (!string.IsNullOrWhiteSpace(request.Search))
                query = query.Where(x => x.Title.ToLower().Contains(request.Search.ToLower()));

            var projectedQuery = query
                .OrderByDescending(x => x.PublishedAt)
                .Select(x => new ListArticlesQueryDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    PublishedAt = x.PublishedAt,
                    AdminName = x.Admin.User.Fullname,
                    Excerpt = x.Content.Length > 10 ? x.Content.Substring(0, 10) + "..." : x.Content
                });

            return await PageResult<ListArticlesQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
        }

        
    }
}
