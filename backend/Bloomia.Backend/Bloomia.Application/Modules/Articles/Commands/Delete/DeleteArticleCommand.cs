using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Articles.Commands.Delete
{
    public class DeleteArticleCommand : IRequest<Unit>
    {
        public required int Id { get; set; }
    }
}
