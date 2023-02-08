using SaeMatrix.Common.Entities.Enum;

namespace SaeMatrix.Common.Entities
{
    public class ResponseDto<T>
    {
        public ResponseDto()
        {
            this.Code = EnumCodeResponse.OK;
            this.Count = 0;
        }

        public T? Data { get; set; }
        public int Count { get; set; } = 0;
        public string Message { get; set; } = string.Empty;
        public EnumCodeResponse Code { get; set; }
    }
}
