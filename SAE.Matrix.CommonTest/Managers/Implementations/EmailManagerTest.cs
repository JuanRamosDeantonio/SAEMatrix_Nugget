using Microsoft.Extensions.Configuration;
using Moq;
using SAE.Matrix.Common.Entities;
using SaeMatrix.Common.Entities;
using SaeMatrix.Common.Managers.Implementations;
using SaeMatrix.Common.Managers.Interfaces;

namespace SAE.Matrix.CommonTest.Managers.Implementations
{
    public class EmailManagerTest
    {
        //private readonly Mock<IConfiguration> _configuration = new Mock<IConfiguration>();
        private ConfigurationBuilder _configuration;
        IEmailManager _current;

        [SetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder();
            _configuration.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { "Smtp:Host", "smtp.office365.com" },
                { "Smtp:Port", "587" },
                { "Smtp:UserName", "AdministradorIMS@saesas.gov.co" },
                { "Smtp:Password", "4pl1c4c10n3sS43" },
                { "Smtp:EnableSsl", "True" }
            });

            _current = new EmailManager(_configuration.Build());
        }

        [Test]
        public async Task SendEmailOKTest()
        {
            //Arrange
            SendEmailRequest model = new SendEmailRequest()
            {
                IsBodyHtml = true,
                Subject = "Pruebas",
                From = "AdministradorIMS@saesas.gov.co",
                To = "oabetancourt@indracompany.com",
                Body = "Probando NUnit Test"
            };

            //Act
            SendEmailResponse result = await _current.SendEmailAsync(model);
            //Assert
            Assert.AreEqual(true, result.Result);
        }

        [Test]
        public async Task SendEmailAttachmentInvalidTest()
        {
            //Arrange
            SendEmailRequest model = new SendEmailRequest()
            {
                IsBodyHtml = true,
                Subject = "Pruebas",
                From = "AdministradorIMS@saesas.gov.co",
                To = "oabetancourt@indracompany.com",
                Body = "Probando NUnit Test",
                Attachments = new List<SendEmailRequest.SendEmailAttachment>() { new SendEmailRequest.SendEmailAttachment() }
            };

            //Act
            SendEmailResponse result = await _current.SendEmailAsync(model);
            //Assert
            Assert.AreNotEqual(null, result.Message);
        }

        [Test]
        public async Task SendEmailWithExceptionTest()
        {
            //Arrange
            SendEmailRequest model = new SendEmailRequest()
            {
                IsBodyHtml = true,
                Subject = "Pruebas",
                From = "AdministradorIMS@saesas.gov.co",
                To = "oabetancourt@indracompany.com",
                Body = "Probando NUnit Test",
                Attachments = new List<SendEmailRequest.SendEmailAttachment>() { new SendEmailRequest.SendEmailAttachment() { Name = "Prueba", Base64 = "XXX" } }
            };

            //Act
            SendEmailResponse result = await _current.SendEmailAsync(model);
            //Assert
            Assert.AreNotEqual(null, result.Message);
        }
    }
}