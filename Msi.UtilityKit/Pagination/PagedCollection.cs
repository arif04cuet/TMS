using Msi.UtilityKit.Sort;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Msi.UtilityKit.Pagination
{
    public class PagedCollection<T>
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Offset { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
        public int Size { get; set; }
        public ICollection<T> Items { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        string[] Sort { get; set; }

        public PagedCollection(ICollection<T> items, int totalCount, IPagingOptions options, ISortOptions sortOptions = null)
        {
            Offset = options?.Offset;
            Limit = options?.Limit;
            Size = totalCount;
            Items = items;
            Sort = sortOptions?.OrderBy;
        }

        public PagedCollection(IEnumerable<T> items, int totalCount, IPagingOptions options, ISortOptions sortOptions = null) : this(items.ToList(), totalCount, options, sortOptions)
        {
        }

        //public T First { get; set; }
        //public T Last { get; set; }
        //public T Next { get; set; }
        //public T Previous { get; set; }
    }
}
