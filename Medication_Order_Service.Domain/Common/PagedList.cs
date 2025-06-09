using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Common
{
    public class PagedList<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public PagedList()
        {
            Items = new List<T>();
        }

        public PagedList(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items ?? new List<T>();
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            HasPrevious = pageNumber > 1;
            HasNext = pageNumber < TotalPages;
        }

        public static PagedList<T> Create(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            return new PagedList<T>(items, totalCount, pageNumber, pageSize);
        }

        public static PagedList<T> Empty()
        {
            return new PagedList<T>(new List<T>(), 0, 1, 10);
        }

        // Pagination metadata for API responses
        public PaginationMetadata GetMetadata()
        {
            return new PaginationMetadata
            {
                TotalCount = TotalCount,
                PageSize = PageSize,
                CurrentPage = PageNumber,
                TotalPages = TotalPages,
                HasNext = HasNext,
                HasPrevious = HasPrevious
            };
        }
    }

    public class PaginationMetadata
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
    }
}
