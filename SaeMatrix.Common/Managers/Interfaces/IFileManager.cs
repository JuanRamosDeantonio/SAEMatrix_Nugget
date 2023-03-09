namespace SAE.Matrix.Common.Managers.Interfaces
{
    using Entities;

    public interface IFileManager
    {
        Task<ResponseBase<bool>> FilesUpload(UploadFilesRequest model);
        Task<ResponseBase<ConsultFileResponse>> ConsultFile(int idDocumento);
        Task<ResponseBase<bool>> DeleteFile(DeleteFileRequest model);
    }
}