namespace SAE.Matrix.Common.Entities
{
    public class UploadFilesRequest
    {
        public UploadFilesRequest()
        {
            estadoRegistro = true;
        }

        public int? idActivo { get; set; }
        public int idElemento { get; set; }
        public string? usuarioRegistro { get; set; }
        public DateTime? fechaRegistro { get; set; }
        public string? operacionRegistro { get; set; }
        public string? maquinaRegistro { get; set; }
        public bool? estadoRegistro { get; set; }

        public List<UploadFileRequest> archivos { get; set; }
    }

    public class UploadFileRequest
    {
        public string tipoMime { get; set; }
        public string nombreArchivo { get; set; }
        public string base64 { get; set; }
        public int idGrupoDocumentalTipoDocumento { get; set; }
    }
}