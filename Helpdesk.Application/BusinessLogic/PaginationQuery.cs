namespace Helpdesk.Application.BusinessLogic
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            PageSize = 100;
            PageNumber = 1;
        }

        public PaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}