namespace Aureum.DTOs
{
    public record PagedResultDTO<T>
    {
        public int Total { get; init; }
        public int Page { get; init; }
        public int PageSize { get; init; }
        public IReadOnlyList<T> Items { get; init; }

        public PagedResultDTO(int total, int Page, int PageSize, IReadOnlyList<T> items)
        {
            this.Total = total;
            this.Page = Page;
            this.PageSize = PageSize;
            this.Items = items;
        }



    }
}
