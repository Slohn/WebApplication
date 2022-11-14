namespace UI.Models
{
    public class PageInfoModel
    {
        public int ItemsCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int DispalayedPages { get; set; }

        public PageInfoModel(int itemsCount, int itemsPerPage, int currentPage, int dispalayedPages) 
        {
            ItemsCount = itemsCount;
            ItemsPerPage = itemsPerPage;
            CurrentPage = currentPage;
            DispalayedPages = dispalayedPages;
        }
    }
}