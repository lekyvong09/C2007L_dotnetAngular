using System;
namespace API.Helpers
{
	public class PaginationParams
	{
        private int MaxPageSize = 50;
        private int _pageSize = 6; /// default value

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}

