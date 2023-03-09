namespace SAE.Matrix.Common.Managers.Interfaces
{
    using Entities;

    public interface IEmailManager
    {
        Task<SendEmailResponse> SendEmailAsync(SendEmailRequest model);
    }
}