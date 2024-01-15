using System.Text.RegularExpressions;

namespace ChangingInRazor.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageInfoModel PageInfoModel { get; set; }

    }


    public class PageInfoModel
    {
        public int TotalItemsCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int ActivePage { get; set; }

        public int TotalPages { get => (int)Math.Ceiling((decimal)TotalItemsCount / ItemsPerPage); }

    }
}
