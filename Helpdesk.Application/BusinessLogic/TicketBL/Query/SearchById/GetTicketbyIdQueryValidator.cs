using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.Tickets.Query.GetTicketById
{
    public class GetTicketbyIdQueryValidator : AbstractValidator<GetHelpdeskTicketByIdQuery>
    {
        public GetTicketbyIdQueryValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}