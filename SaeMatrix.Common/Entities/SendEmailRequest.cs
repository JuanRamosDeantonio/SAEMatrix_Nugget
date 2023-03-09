namespace SAE.Matrix.Common.Entities
{
    public class SendEmailRequest
    {
        public SendEmailRequest() 
        {
            IsBodyHtml= true;
        }

        public string? From { get; set; }
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public bool IsBodyHtml { get; set; }

        public List<SendEmailAttachment>? Attachments { get; set; }

        public class SendEmailAttachment
        {
            public string Name { get; set; }
            public string Base64 { get; set; }
        }
    }
}