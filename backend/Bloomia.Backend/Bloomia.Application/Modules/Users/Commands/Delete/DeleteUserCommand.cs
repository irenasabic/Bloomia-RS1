using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public required int Id { get; set; } 
    }
}
