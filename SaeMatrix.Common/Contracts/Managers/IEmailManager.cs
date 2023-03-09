namespace SAE.Matrix.Common.Contracts.Managers
{
    using Entities;

    public interface IEmailManager
    {
        Task<SendEmailResponse> SendEmailAsync(SendEmailRequest model);
    }
}