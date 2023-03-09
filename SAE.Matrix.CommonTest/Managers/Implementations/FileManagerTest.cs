using Microsoft.Extensions.Configuration;
using Moq;

namespace SAE.Matrix.CommonTest.Managers.Implementations
{
    using Common.Entities;
    using Common.Managers.Implementations;
    using Common.Managers.Interfaces;
    using Common.Routine.Contracts;

    public class FileManagerTest
    {
        private ConfigurationBuilder _configuration;
        private readonly Mock<ISenderManager> _senderManagerMock = new Mock<ISenderManager>();
        IFileManager _current;

        [SetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder();
            _configuration.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { "Services:File", @"https://localhost:7120" }
            });

            _current = new FileManager(_configuration.Build(), _senderManagerMock.Object);
        }

        [Test]
        public async Task FilesUpload_OK_Test()
        {
            //Arrange
            _senderManagerMock.Setup(x => x.SendRequest<bool>(It.IsAny<HttpRequestMessage>(), It.IsAny<string>(), null)).Returns(Task.FromResult(new ResponseBase<bool>() { Data = true }));
            //Act
            ResponseBase<bool> result = await _current.FilesUpload(new UploadFilesRequest());
            //Assert
            Assert.IsTrue(result.Data);
        }

        [Test]
        public async Task FilesUpload_WithError_Test()
        {
            //Arrange
            _senderManagerMock.Setup(x => x.SendRequest<bool>(It.IsAny<HttpRequestMessage>(), It.IsAny<string>(), null)).Returns(Task.FromResult(new ResponseBase<bool>() { Data = false }));
            //Act
            ResponseBase<bool> result = await _current.FilesUpload(new UploadFilesRequest());
            //Assert
            Assert.IsFalse(result.Data);
        }

        [Test]
        public async Task ConsultFile_OK_Test()
        {
            //Arrange
            _senderManagerMock.Setup(x => x.SendRequest<ConsultFileResponse>(It.IsAny<HttpRequestMessage>(), It.IsAny<string>(), null)).Returns(Task.FromResult(new ResponseBase<ConsultFileResponse>() { Data = new ConsultFileResponse() }));
            //Act
            ResponseBase<ConsultFileResponse> result = await _current.ConsultFile(It.IsAny<int>());
            //Assert
            Assert.IsTrue(result.Data != null);
        }

        [Test]
        public async Task ConsultFile_WithError_Test()
        {
            //Arrange
            _senderManagerMock.Setup(x => x.SendRequest<ConsultFileResponse>(It.IsAny<HttpRequestMessage>(), It.IsAny<string>(), null)).Returns(Task.FromResult(new ResponseBase<ConsultFileResponse>() { Data = null }));
            //Act
            ResponseBase<ConsultFileResponse> result = await _current.ConsultFile(It.IsAny<int>());
            //Assert
            Assert.IsTrue(result.Data == null);
        }

        [Test]
        public async Task DeleteFile_OK_Test()
        {
            //Arrange
            _senderManagerMock.Setup(x => x.SendRequest<bool>(It.IsAny<HttpRequestMessage>(), It.IsAny<string>(), null)).Returns(Task.FromResult(new ResponseBase<bool>() { Data = true }));
            //Act
            ResponseBase<bool> result = await _current.DeleteFile(new DeleteFileRequest());
            //Assert
            Assert.IsTrue(result.Data);
        }

        [Test]
        public async Task DeleteFile_WithError_Test()
        {
            //Arrange
            _senderManagerMock.Setup(x => x.SendRequest<bool>(It.IsAny<HttpRequestMessage>(), It.IsAny<string>(), null)).Returns(Task.FromResult(new ResponseBase<bool>() { Data = false }));
            //Act
            ResponseBase<bool> result = await _current.DeleteFile(new DeleteFileRequest());
            //Assert
            Assert.IsFalse(result.Data);
        }
    }
}