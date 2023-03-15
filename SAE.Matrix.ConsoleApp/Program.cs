// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SAE.Matrix.Common.Contracts.Managers;
using SAE.Matrix.Common.Entities;
using SAE.Matrix.Common.Implementations.Managers;

Console.WriteLine("Hello, World!");

try
{
    ConfigurationBuilder configuration = new ConfigurationBuilder();
    configuration.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { "Services:File", "https://localhost:7120" },
                { "AD:Domain", "saesas.gov.co" },
                { "AD:Path", "LDAP://dcserversae10.saesas.gov.co" },
                { "AD:DN", "DC=saesas,DC=gov,DC=co" },
                { "AD:UserName", "ldapmatrix20@saesas.gov.co" },
                { "AD:Password", "Saesas2018+" }
            });

    var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddHttpClient();
                   services.AddHttpContextAccessor();
                   services.AddScoped<IFileManager, FileManager>();
                   services.AddScoped<ISenderManager, SenderManager>();
                   services.AddScoped<ILDAPManager, LDAPManager>();
                   services.AddSingleton<IConfiguration>(configuration.Build());
               }).UseConsoleLifetime();

    var host = builder.Build();

    ILDAPManager lDAPManager = host.Services.GetService<ILDAPManager>();
    var result = lDAPManager.GetUserInfo("ldapmatrix20", "Saesas2018+", new string[] { "sAMAccountName", "mail", "employeeID", "title", "userAccountControl" });

    //IFileManager fileService = host.Services.GetService<IFileManager>();

    //UploadFilesRequest model = new UploadFilesRequest()
    //{
    //    idActivo = null,
    //    idElemento = 1,
    //    usuarioRegistro = "Oscar",
    //    fechaRegistro = DateTime.Now,
    //    operacionRegistro = "C",
    //    maquinaRegistro = ":::",
    //    estadoRegistro = true,
    //    archivos = new List<UploadFileRequest>()
    //    {
    //        { new UploadFileRequest() { idGrupoDocumentalTipoDocumento = 1, tipoMime = @"application/pdf", nombreArchivo = "xxx.pdf", base64 = "UHJvYmFuZG8gZWwgbnVldm8gc2VydmljaW8gUkVTVA==" } }
    //    }
    //};

    ////var response = fileService.FilesUpload(model);
    ////var response2 = fileService.ConsultFile(23530);
    ////var response3 = fileService.DeleteFile(new DeleteFileRequest() { idElemento = 1, idDocumento = 23530, usuarioRegistro = "Pruebas", maquinaRegistro = ":::" });
    //var response3 = fileService.ConsultFiles(1, "Acta de posesion");

    Console.ReadKey();
}
catch (Exception ex)
{
	Console.WriteLine($"Error: {ex.Message}");
}