using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Query.List
{
    public class ListAvailableTimesByDateQueryValidator:AbstractValidator<ListAvailableTimesByDateQuery>
    {
        public ListAvailableTimesByDateQueryValidator()
        {
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is mandatory!");
        }
    }
}
