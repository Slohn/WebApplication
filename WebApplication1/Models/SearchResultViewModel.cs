namespace UI.Models
{
    public class SearchResultViewModel<TModel>
    {
        public IList<TModel> Objects { get; set; }
        public PageInfoModel PagesInfo { get; set; }   

        public SearchResultViewModel(IEnumerable<TModel> objects, int totalCount, int requestedSrartIndex,            int? requestedCount, int displayedPages)        {
            var pageSize = Math.Max(1,requestedCount ?? totalCount - requestedSrartIndex);
            Objects = objects.ToList();
            PagesInfo = new PageInfoModel(totalCount, pageSize, requestedSrartIndex/pageSize + 1, displayedPages);
        }

    }

    public class SearchResultViewModel<TModel, TFilterModel> : SearchResultViewModel<TModel> 
    {
        public TFilterModel FilterModel { get; set; }

        public SearchResultViewModel(IEnumerable<TModel> objects, TFilterModel filterModel, int totalCount, int requestedStartIndex,
            int? requestedCount, int displayedPages) : base(objects, totalCount, requestedStartIndex, requestedCount, displayedPages)
        {
            FilterModel = filterModel;
        }
    }
}
