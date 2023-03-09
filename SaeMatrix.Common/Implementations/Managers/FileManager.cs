using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace SAE.Matrix.Common.Implementations.Managers
{
    using Entities;
    using Contracts.Managers;

    public class FileManager : IFileManager
    {
        private readonly IConfiguration _configuration;
        private readonly ISenderManager _senderManager;

        public FileManager(IConfiguration configuration,
            ISenderManager senderManager)
        {
            _configuration = configuration;
            _senderManager = senderManager;
        }

        public async Task<ResponseBase<bool>> FilesUpload(UploadFilesRequest model)
        {
            string baseUrlService = _configuration.GetSection("Services:File").Value;
            //string baseUrlService = @"https://localhost:7120";

            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, @"application/json"),
                RequestUri = new Uri($@"{baseUrlService}/File")
            };

            ResponseBase<bool> result = await _senderManager.SendRequest<bool>(requestMessage, "FileService");
            return result;
        }

        public async Task<ResponseBase<ConsultFileResponse>> ConsultFile(int idDocumento)
        {
            string baseUrlService = _configuration.GetSection("Services:File").Value;
            //string baseUrlService = @"https://localhost:7120";

            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($@"{baseUrlService}/File?idDocumento={idDocumento}")
            };

            ResponseBase<ConsultFileResponse> result = await _senderManager.SendRequest<ConsultFileResponse>(requestMessage, "FileService");
            return result;
        }

        public async Task<ResponseBase<bool>> DeleteFile(DeleteFileRequest model)
        {
            string baseUrlService = _configuration.GetSection("Services:File").Value;
            //string baseUrlService = @"https://localhost:7120";

            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($@"{baseUrlService}/File")
            };

            ResponseBase<bool> result = await _senderManager.SendRequest<bool>(requestMessage, "FileService");
            return result;
        }
    }
}