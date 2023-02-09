namespace SAE.Matrix.Common.Entities
{
    public class SendEmailResponse
    {
        public SendEmailResponse()
        {
            Result = false;
            Message = string.Empty;
        }

        public bool Result { get; set; }
        public string Message { get; set; }
    }
}