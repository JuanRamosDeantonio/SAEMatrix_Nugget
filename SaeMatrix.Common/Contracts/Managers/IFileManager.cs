namespace SAE.Matrix.Common.Contracts.Managers
{
    using Entities;

    public interface IFileManager
    {
        Task<ResponseBase<bool>> FilesUpload(UploadFilesRequest model);
        Task<ResponseBase<ConsultFileResponse>> ConsultFile(int idDocumento);
        Task<ResponseBase<List<ConsultFilesResponse>>> ConsultFiles(int idElemento, string grupoDocumental);
        Task<ResponseBase<bool>> DeleteFile(DeleteFileRequest model);
    }
}