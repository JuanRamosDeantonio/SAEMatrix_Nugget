using SAE.Matrix.Common.Entities;
using SaeMatrix.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaeMatrix.Common.Managers.Interfaces
{
    public interface IEmailManager
    {
        Task<SendEmailResponse> SendEmailAsync(SendEmailRequest model);
    }
}