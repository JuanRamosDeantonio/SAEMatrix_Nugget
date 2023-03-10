namespace SAE.Matrix.Common.Entities
{
    public class DeleteFileRequest
    {
        public int idElemento { get; set; }
        public int idDocumento { get; set; }
        public string? usuarioRegistro { get; set; }
        public string? maquinaRegistro { get; set; }
    }
}