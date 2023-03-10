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

            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, @"application/json"),
                RequestUri = new Uri($@"{baseUrlService}/File/FilesUpload")
            };

            ResponseBase<bool> result = await _senderManager.SendRequest<bool>(requestMessage, "FileService");
            return result;
        }

        public async Task<ResponseBase<ConsultFileResponse>> ConsultFile(int idDocumento)
        {
            string baseUrlService = _configuration.GetSection("Services:File").Value;

            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($@"{baseUrlService}/File/ConsultFile/{idDocumento}")
            };

            ResponseBase<ConsultFileResponse> result = await _senderManager.SendRequest<ConsultFileResponse>(requestMessage, "FileService");
            return result;
        }

        public async Task<ResponseBase<List<ConsultFilesResponse>>> ConsultFiles(int idElemento, string grupoDocumental)
        {
            string baseUrlService = _configuration.GetSection("Services:File").Value;

            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($@"{baseUrlService}/File/ConsultFiles/{idElemento}/{grupoDocumental}")
            };

            ResponseBase<List<ConsultFilesResponse>> result = await _senderManager.SendRequest<List<ConsultFilesResponse>>(requestMessage, "FileService");
            return result;
        }

        public async Task<ResponseBase<bool>> DeleteFile(DeleteFileRequest model)
        {
            string baseUrlService = _configuration.GetSection("Services:File").Value;

            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, @"application/json"),
                RequestUri = new Uri($@"{baseUrlService}/File/DeleteFile")
            };

            ResponseBase<bool> result = await _senderManager.SendRequest<bool>(requestMessage, "FileService");
            return result;
        }
    }
}