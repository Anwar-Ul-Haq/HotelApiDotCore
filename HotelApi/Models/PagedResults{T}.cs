using System.Collections.Generic;

namespace HotelApi.Models
{
    public class PagedResults<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int TotalSize { get; set; }
    }
}
