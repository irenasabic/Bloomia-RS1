using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Articles.Queries.List
{
    public class ListArticlesQuery : BasePagedQuery<ListArticlesQueryDto>
    {
        public string? Search { get; init; }
    }
}
