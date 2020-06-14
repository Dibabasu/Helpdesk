using FluentValidation;
using Helpdesk.Application.BusinessLogic.StatusBL.Query.GetbyCode;

namespace Helpdesk.Application.BusinessLogic.StatusBL.Query.GetStatusbyCode
{
    public class GetStatusbyIdValidation : AbstractValidator<GetStatusByCodeQuery>
    {
        public GetStatusbyIdValidation()
        {
            RuleFor(x => x.StatusCode).NotEmpty().MaximumLength(6);
        }
    }
}