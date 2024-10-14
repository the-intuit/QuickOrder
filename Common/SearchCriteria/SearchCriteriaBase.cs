using Menu.Common.Enums;

namespace Menu.Common.SearchCriteria
{
    public class SearchCriteriaBase
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public SortDirection Direction { get; set; }

        public SearchCriteriaBase()
        {
            Page = 1;
            Direction = SortDirection.Descending;
            PageSize = Constants.Defaults.PageSize;
        }
    }
}
