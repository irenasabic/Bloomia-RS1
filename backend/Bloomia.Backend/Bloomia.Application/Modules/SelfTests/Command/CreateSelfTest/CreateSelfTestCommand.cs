using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.SelfTests.Command.CreateSelfTest
{
    public class CreateSelfTestCommand: IRequest<CreateSelfTestCommandDto>
    {
        //admin unosi title i pitanja
        public string Title { get; init; }
        public List<CreateSelfTestStatementCommandDto> Statements { get; init; } = new List<CreateSelfTestStatementCommandDto>();

    }

}
