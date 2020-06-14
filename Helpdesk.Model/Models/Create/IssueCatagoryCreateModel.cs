using System;

namespace Helpdesk.Create
{
    public class IssueCatagoryCreateModel
    {
        public Guid Id { get; set; }
        public String IssueCatagoryCode { get; set; }
        public String Description { get; set; }
    }
}