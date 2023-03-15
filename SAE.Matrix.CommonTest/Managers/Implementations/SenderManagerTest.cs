using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using SAE.Matrix.Common.Contracts.Managers;
using SAE.Matrix.Common.Entities;
using SAE.Matrix.Common.Implementations.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SAE.Matrix.CommonTest.Managers.Implementations
{
    public class SenderManagerTest
    {
        private ConfigurationBuilder _configuration;
        private Mock<IHttpClientFactory> _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        private Mock<IHttpContextAccessor> _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        private Mock<ISenderManager> _senderManagerMock = new Mock<ISenderManager>();
        ISenderManager _current;

        [SetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder();
            _configuration.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { "Json", "{ \"url\": \"https://localhost:7154\", \"BaseAddress\": \"https://localhost:7154\" }" }
            });

            _current = new SenderManager(_configuration.Build(), _httpClientFactoryMock.Object, _httpContextAccessorMock.Object);
        }

        [Test]
        public async Task SendRequest_OK_Test()
        {
            //Arrange
            Mock<HttpClient> client= new Mock<HttpClient>();
            _httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client.Object);

            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($@"https://www.google.com.co/")
            };

            //Act
            ResponseBase<string> result = await _current.SendRequest<string>(requestMessage, "Pruebas", complement: null);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task SendRequest_WithError_Test()
        {
            //Arrange
            Mock<HttpClient> client = new Mock<HttpClient>();
            _httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>())).Throws(new Exception("Error..."));

            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($@"https://www.google.com.co/")
            };

            //Act
            ResponseBase<string> result = await _current.SendRequest<string>(requestMessage, "Pruebas", complement: null);
            //Assert
            Assert.IsTrue(result.Code == (int)HttpStatusCode.InternalServerError);
        }

        [Test]
        public void GetConfigurationTest()
        {
            //Arrange
            //Act
            RequestConfig requestConfig = _current.GetConfiguration("Json");
            //Assert
            Assert.IsNotNull(requestConfig);
        }
    }
}