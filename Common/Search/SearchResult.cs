using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Search
{
    public class SearchResult<T>
    {
        public int Total { get; set; }
        public IList<T> Objects { get; set; }
        public int RequestedStartIndex { get; set; }
        public int? RequestedObjectsCount { get; set; }     
        public SearchResult(int total, IList<T> objects, int requestedStartIndex, int? requestedObjectsCount)
        {
            Total = total;
            Objects = objects.ToList();
            RequestedStartIndex = requestedStartIndex;
            RequestedObjectsCount = requestedObjectsCount;
        }

        public SearchResult() { }
    }
}
