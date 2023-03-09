using System.Diagnostics;
using System.Net;

namespace SAE.Matrix.Common.Entities
{
    public class ResponseBase<T> : ICloneable
    {
        public ResponseBase()
        {
        }
        public ResponseBase(int Code, string Message, T? Data, int Count)
        {
            this.Code = Code;
            this.Message = Message;
            this.Data = Data;
            this.Count = Count;
        }

        public ResponseBase(int Code, string Message)
        {
            this.Code = Code;
            this.Message = Message;
            this.Count = 0;
        }
        private Stopwatch? _timer; public ResponseBase(bool startTimer = false)
        {
            Message = "";
            Code = (int)HttpStatusCode.OK;
            ProcessTimeSeg = 0;
            if (startTimer) StartTimer();
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public void StartTimer()
        {
            _timer = Stopwatch.StartNew();
        }
        public ResponseBase<T> StopTimer()
        {
            if (_timer != null)
            {
                _timer.Stop();
                var num = 0m;
                var isDecimal = decimal.TryParse(_timer.Elapsed.TotalSeconds.ToString(), out num);
                num = isDecimal ? num : 0m; ProcessTimeSeg = num;
            }
            return this;
        }
        public int Code { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public int Count { get; set; }
        public decimal ProcessTimeSeg { get; set; }
    }
}