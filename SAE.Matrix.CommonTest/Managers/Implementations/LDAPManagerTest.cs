using Microsoft.Extensions.Configuration;
using Moq;
using SAE.Matrix.Common.Contracts.Managers;
using SAE.Matrix.Common.Entities;
using SAE.Matrix.Common.Implementations.Managers;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SAE.Matrix.CommonTest.Managers.Implementations
{
    public class LDAPManagerTest
    {
        //private ConfigurationBuilder _configuration;
        //ILDAPManager _current;

        //[SetUp]
        //public void Setup()
        //{
        //    _configuration = new ConfigurationBuilder();
        //    _configuration.AddInMemoryCollection(new Dictionary<string, string>()
        //    {
        //        { "AD:Domain", "saesas.gov.co" },
        //        { "AD:Path", "LDAP://dcserversae10.saesas.gov.co" },
        //        { "AD:DN", "DC=saesas,DC=gov,DC=co" },
        //        { "AD:UserName", "ldapmatrix20@saesas.gov.co" },
        //        { "AD:Password", "Saesas2018+" }
        //    });

        //    _current = new LDAPManager(_configuration.Build());
        //}

        //[Test]
        //public void GetUserInfo_OK_Test()
        //{
        //    //Arrange
        //    string username = "pruebas";
        //    string password = "123456";
        //    string[] propertiesToLoad = new string[] { "sAMAccountName", "mail", "employeeID", "title", "userAccountControl" };
        //    //Mock<DirectorySearcher> directorySeacherMock = new Mock<DirectorySearcher>();
        //    //Mock<SearchResult> searchResultMock = new Mock<SearchResult>();
        //    //directorySeacherMock.Setup(x => x.FindOne()).Returns(searchResultMock.Object);
        //    //Act
        //    ResponseBase<SearchResult> result = _current.GetUserInfo(username, password, propertiesToLoad);
        //    //Assert
        //    Assert.IsTrue(result.Code == (int)HttpStatusCode.OK);
        //}
    }
}