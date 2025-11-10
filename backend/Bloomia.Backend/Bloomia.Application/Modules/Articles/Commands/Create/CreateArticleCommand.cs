using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Articles.Commands.Create
{
    public class CreateArticleCommand : IRequest<int>
    {
        //ne šaljemo AdminId, uzima se Id od trenutno prijavljenog admina
        //public required int AdminId { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
    }
}
