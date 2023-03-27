namespace SAE.Matrix.Common.Entities
{
    public class PaginationRequest<T>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public T Filter { get; set; }
    }
}