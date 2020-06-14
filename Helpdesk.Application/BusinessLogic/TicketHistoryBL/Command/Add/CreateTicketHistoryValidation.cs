using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Helpdesk.Application.BusinessLogic.TicketHistoryBL.Command.Add
{
  public  class CreateTicketHistoryValidation : AbstractValidator<CreateTicketHistoryCommand>
    {
        public CreateTicketHistoryValidation()
        {
            RuleFor(x => x.User.UserName).NotEmpty();
            RuleFor(x => x.TicketHistory.Response).NotEmpty();
            RuleFor(x => x.TicketHistory.Status).NotEmpty();
            RuleFor(x => x.TicketHistory.TicketId).NotEmpty();
            RuleFor(x => x.TicketHistory.TicketNumber).NotEmpty();
        }
    }
}
