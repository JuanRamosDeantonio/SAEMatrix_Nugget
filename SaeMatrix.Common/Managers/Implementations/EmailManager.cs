using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace SAE.Matrix.Common.Managers.Implementations
{
    using Entities;
    using Interfaces;
    using static Entities.SendEmailRequest;

    public class EmailManager : IEmailManager
    {
        private readonly IConfiguration _configuration;

        public EmailManager(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        public async Task<SendEmailResponse> SendEmailAsync(SendEmailRequest model)
        {
            SendEmailResponse response = new SendEmailResponse();
            try
			{
                // Validaciones
                if (string.IsNullOrWhiteSpace(model.From)) response.Message += "Model.From invalido|";
                if (string.IsNullOrWhiteSpace(model.To)) response.Message += "Model.To invalido|";
                if (string.IsNullOrWhiteSpace(model.Subject)) response.Message += "Model.Subject invalido|";
                if (string.IsNullOrWhiteSpace(model.Body)) response.Message += "Model.Body invalido|";

                if(model.Attachments != null) 
                {
                    foreach (SendEmailAttachment attachment in model.Attachments)
                    {
                        if(string.IsNullOrWhiteSpace(attachment.Name) || string.IsNullOrWhiteSpace(attachment.Base64))
                        {
                            response.Message += "Archivos adjuntos invalidos|";
                            break;
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(response.Message)) return response;

                using (SmtpClient client = new SmtpClient())
                {
                    MailMessage mailMessage = new MailMessage()
                    {
                        IsBodyHtml = model.IsBodyHtml,
                        Subject = model.Subject,
                        Body = model.Body,
                        From = new MailAddress(model.From)
                    };

                    string[] emailsArray = model.To.Split(new char[] { ';' });
                    foreach (string email in emailsArray)
                    {
                        mailMessage.To.Add(new MailAddress(email));
                    }

                    if (model.Attachments != null && model.Attachments.Count > 0)
                    {
                        model.Attachments.ForEach(attachment => mailMessage.Attachments.Add(new Attachment(new MemoryStream(Convert.FromBase64String(attachment.Base64)), attachment.Name)));
                    }

                    client.Host = _configuration.GetSection("Smtp:Host").Value;
                    client.Port = int.Parse(_configuration.GetSection("Smtp:Port").Value);
                    client.Credentials = new NetworkCredential(_configuration.GetSection("Smtp:UserName").Value, _configuration.GetSection("Smtp:Password").Value);
                    client.EnableSsl = bool.Parse(_configuration.GetSection("Smtp:EnableSsl").Value);
                    
                    await client.SendMailAsync(mailMessage);
                    response.Result = true;
                }
            }
			catch (Exception ex)
			{
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
