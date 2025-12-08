using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Query.ListBookedTimesByDate
{
    public class ListBookedTimesByDateQueryValidator:AbstractValidator<ListBookedTimesByDateQuery>
    {
        public ListBookedTimesByDateQueryValidator()
        {
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is mandatory!");
        }
    }
}
