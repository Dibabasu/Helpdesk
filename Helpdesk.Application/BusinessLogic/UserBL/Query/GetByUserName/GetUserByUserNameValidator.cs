using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpdesk.Application.BusinessLogic.UserBL.Query.GetByUserName
{
    public class GetUserByUserNameValidator : AbstractValidator<GetUserByUserNameQuery>
    {
        public GetUserByUserNameValidator()
        {
            RuleFor(r => r.UserName)
                .NotEmpty();
        }
    }
}
