using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Therapists.Commands.Update.ChangeTherapistPassword
{
    public sealed class ChangeTherapistPasswordCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
