namespace SAE.Matrix.Common.Entities
{
    public class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public int FirstRowOnPage => (CurrentPage - 1) * PageSize + 1;
        public int LastRowOnPage => Math.Min(CurrentPage * PageSize, RowCount);
    }

    public class PagedResult<TEntity> : PagedResultBase where TEntity : class
    {
        public List<TEntity> Results { get; set; }
        public PagedResult()
        {
            Results = new List<TEntity>();
        }
    }

    public class PagedOneResult<TEntity> : PagedResultBase where TEntity : class
    {
        public TEntity Result { get; set; }
        public PagedOneResult(TEntity entity)
        {
            Result = entity;
        }
    }
}