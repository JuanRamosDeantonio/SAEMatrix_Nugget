// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SAE.Matrix.Common.Entities;
using SAE.Matrix.Common.Managers.Implementations;
using SAE.Matrix.Common.Managers.Interfaces;
using SAE.Matrix.Common.Routine;
using SAE.Matrix.Common.Routine.Contracts;

Console.WriteLine("Hello, World!");

try
{
    IConfiguration configuration = new ConfigurationBuilder()
    .Build();

    var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddHttpClient();
                   services.AddHttpContextAccessor();
                   services.AddScoped<IFileManager, FileManager>();
                   services.AddScoped<ISenderManager, SenderManager>();
                   services.AddSingleton<IConfiguration>(configuration);
               }).UseConsoleLifetime();

    var host = builder.Build();

    IFileManager fileService = host.Services.GetService<IFileManager>();

    UploadFilesRequest model = new UploadFilesRequest()
    {
        idActivo = null,
        idElemento = 1,
        usuarioRegistro = "Oscar",
        fechaRegistro = DateTime.Now,
        operacionRegistro = "C",
        maquinaRegistro = ":::",
        estadoRegistro = true,
        archivos = new List<UploadFileRequest>()
        {
            { new UploadFileRequest() { idGrupoDocumentalTipoDocumento = 1, tipoMime = @"application/pdf", nombreArchivo = "xxx.pdf", base64 = "UHJvYmFuZG8gZWwgbnVldm8gc2VydmljaW8gUkVTVA==" } }
        }
    };

    var response = fileService.FilesUpload(model);

    Console.ReadKey();
}
catch (Exception ex)
{
	Console.WriteLine($"Error: {ex.Message}");
}