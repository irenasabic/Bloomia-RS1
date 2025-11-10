using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Articles.Queries.GetById
{
    public class GetArticleByIdQueryDto
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get;set; }
        public required DateTime PublishedAt { get; set; }
        public required string AdminName { get; set; }
    }
}
