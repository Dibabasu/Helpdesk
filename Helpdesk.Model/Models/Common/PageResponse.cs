namespace Helpdesk.Application.Models.Common
{
    public class PageResponse
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public string NextPage { get; set; }
        public string PreviousPage { get; set; }
    }
}