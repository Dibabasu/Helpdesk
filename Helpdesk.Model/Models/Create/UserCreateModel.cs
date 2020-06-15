using System;

namespace Helpdesk.Model.Models.Create
{
    public class UserCreateModel
    {
        public Guid UserId { get; set; }
        public String UserName { get; set; }
        public String DepartmentName { get; set; }
        public String Division { get; set; }
        public String FirstMidName { get; set; }
        public String LastName { get; set; }
    }
}
