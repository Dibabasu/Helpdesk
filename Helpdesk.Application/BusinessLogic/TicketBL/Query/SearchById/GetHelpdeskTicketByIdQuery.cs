using Helpdesk.Models;
using MediatR;
using System;

namespace Helpdesk.Application.BusinessLogic.Tickets.Query.GetTicketById
{
    public class GetHelpdeskTicketByIdQuery : IRequest<HelpdeskTicketModel>
    {
        public Guid Id { get; set; }
    }
}