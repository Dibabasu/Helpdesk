using Helpdesk.Application.BusinessLogic.LastTicketBL.Command.Update;
using Helpdesk.Application.BusinessLogic.LastTicketBL.Query.GetLastTicketByYear;
using Helpdesk.Application.BusinessLogic.StatusBL.Query.GetbyCode;
using Helpdesk.Application.BusinessLogic.TicketHistoryBL.Command.Add;
using Helpdesk.Application.Interface;
using Helpdesk.Application.Models.Ticket;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Models.Create;
using Helpdesk.Models;
using Helpdesk.Shared.Constant;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.TicketBL.Command.AddTicket
{
    public class CreateNewTicketCommand : IRequest
    {
        public CreateTicketModel TicketModel { get; set; }
        public UserModel UserModel { get; set; }

        public class CreateNewTicketHandler : IRequestHandler<CreateNewTicketCommand, Unit>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMediator _mediator;

            public CreateNewTicketHandler(IHelpdeskDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(
                CreateNewTicketCommand request,
                CancellationToken cancellationToken)
            {
                using var trans = _context.Database.BeginTransaction();
                try
                {
                    var helpdeskTicket = await AddHelpdeskTicket(request, cancellationToken);
                    await AddHelpdeskHistory(helpdeskTicket, request.UserModel);
                    trans.Commit();
                    return Unit.Value;
                }
                catch (Exception)
                {
                    await trans.RollbackAsync();
                    throw;

                }

                finally
                {
                    trans.Dispose();

                }
            }
            private async Task<Unit> AddHelpdeskHistory(HelpdeskTicket TicketDetails, UserModel request)
            {
                await _mediator.Send(new CreateTicketHistoryCommand
                {
                    TicketHistory = new TicketHistoryCreateModel
                    {
                        Response = Constants.NewTicketHistoryResponse,
                        Status = TicketDetails.StatusId,
                        TicketId = TicketDetails.TicketId,
                        TicketNumber = TicketDetails.TicketNumber,
                        ElapsedTime = 0,
                    },
                    User = request

                });
                return Unit.Value;
            }
            private async Task<HelpdeskTicket> AddHelpdeskTicket
                (CreateNewTicketCommand request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var entity = new HelpdeskTicket
                    {
                        Detail = request.TicketModel.Desciption,
                        IssueSubCatagoryId = request.TicketModel.IssueSubCatagoryId,
                        CreatedBy = request.UserModel.UserName,
                        LastModifiedBy = request.UserModel.UserName,
                        IssueTypeId = request.TicketModel.IssueTypeId,
                        LocationId = request.TicketModel.LocationId,
                        ReportedBy = request.UserModel.UserId,
                        PriorityLevel = request.TicketModel.PriorityLevel,
                        StatusId = _mediator.Send(
                            new GetStatusByCodeQuery
                            {
                                StatusCode = Constants.NewTicketStatus
                            }
                            ).Result.Id,
                        TicketNumber = GetTicketNumber(out long UpdateTicketNo)

                    };
                    _context.Set<HelpdeskTicket>().Add(entity);

                    await _context.SaveChangesAsync(cancellationToken);

                    await _mediator.Send(new UpdateLastTicketCommand
                    {
                        TicketNumber = UpdateTicketNo
                    });

                    return entity;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            private string GetTicketNumber(out long UpdateTicketno)
            {


                long LastTicekt = _mediator.Send(new GetLastTicketByYearCommand()).Result.LastTicketNo + 1;
                string TicketNo = String.Format("{0}{1}{2}",
                    DateTime.UtcNow.Year.ToString(),
                    DateTime.UtcNow.Month.ToString(Constants.monthFormat),
                    LastTicekt.ToString(Constants.TicketNumberFormat)
                    );
                UpdateTicketno = LastTicekt;
                return TicketNo;
            }
        }
    }
}