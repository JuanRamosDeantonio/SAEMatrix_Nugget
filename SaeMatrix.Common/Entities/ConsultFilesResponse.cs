namespace SAE.Matrix.Common.Entities
{
    public class ConsultFilesResponse
    {
        public int idDocumento { get; set; }
        public string? nombreDocumento { get; set; }
        public string? tipoMimeDocumento { get; set; }
        public string? rutaDocumento { get; set; }
        public DateTime? fechaRegistro { get; set; }
        public int? idRadicado { get; set; }
        public long? numeroRadicado { get; set; }
    }
}