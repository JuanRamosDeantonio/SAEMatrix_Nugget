namespace SAE.Matrix.Common.Entities
{
    public class PaginationResponse<T>
    {
        public int TotalRecords { get; set; }
        public T Result { get; set; }
    }
}