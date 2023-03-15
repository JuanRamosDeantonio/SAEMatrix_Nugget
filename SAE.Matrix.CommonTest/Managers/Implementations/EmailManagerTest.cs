using Microsoft.Extensions.Configuration;
using Moq;



namespace SAE.Matrix.CommonTest.Managers.Implementations
{
    using Common.Entities;
    using Common.Contracts.Managers;
    using Common.Implementations.Managers;

    public class EmailManagerTest
    {
        private ConfigurationBuilder _configuration;
        IEmailManager _current;

        [SetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder();
            _configuration.AddInMemoryCollection(new Dictionary<string, string>()
            {
                //{ "Smtp:Host", "smtp.office365.com" },
                //{ "Smtp:Port", "587" },
                //{ "Smtp:UserName", "AdministradorIMS@saesas.gov.co" },
                //{ "Smtp:Password", "4pl1c4c10n3sS43" },
                //{ "Smtp:EnableSsl", "True" }

                //{ "Smtp:Host", "smtp.gmail.com" },
                //{ "Smtp:Port", "465" },
                //{ "Smtp:UserName", "indraprojecttesting@gmail.com" },
                //{ "Smtp:Password", "Indra_2023*" },
                //{ "Smtp:EnableSsl", "True" }

                { "Smtp:Host", "smtp.office365.com" },
                { "Smtp:Port", "587" },
                { "Smtp:UserName", "indraprojecttesting@hotmail.com" },
                { "Smtp:Password", "Indra_2023*" },
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
                From = "indraprojecttesting@hotmail.com",
                To = "rjmaestre@indracompany.com;oabetancourt@indracompany.com",
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