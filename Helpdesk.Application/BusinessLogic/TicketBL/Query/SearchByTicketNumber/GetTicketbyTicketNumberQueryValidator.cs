using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.Tickets.Query.GetTicketByNumber
{
    public class GetHelpdeskTicketByTicektNumberQueryValidator : AbstractValidator<GetHelpdeskTicketByTicektNumberQuery>
    {
        public GetHelpdeskTicketByTicektNumberQueryValidator()
        {
            RuleFor(r => r.TicketNumber)
                .NotEmpty();
        }
    }
}