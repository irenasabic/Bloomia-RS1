using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Articles.Queries.List
{
    public class ListArticlesQueryDto
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Excerpt { get; set; }
        public required DateTime PublishedAt { get; set; }
        public required string AdminName { get; set; }
    }
}
