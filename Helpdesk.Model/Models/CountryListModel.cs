using Helpdesk.Application.Models.Common;
using System.Collections.Generic;

namespace Helpdesk.Models
{
    public class CountryListModel 
    {
        public IList<CountryModel> Countries { get; set; }
    }
}