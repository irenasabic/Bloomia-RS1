using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Articles.Queries.GetById
{
    public class GetArticleByIdQuery : IRequest<GetArticleByIdQueryDto>
    {
        public int Id { get; set; }
    }
}
