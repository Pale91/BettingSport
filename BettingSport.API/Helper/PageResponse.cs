using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSport.API.Helper
{
    public class PageResponse<T>
    {
        public PageResponse(int pageNumber = Constants.PAGE_NUMBER, int pageSize = Constants.PAGE_SIZE, IEnumerable<T> data = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data ?? new List<T>();
        }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
