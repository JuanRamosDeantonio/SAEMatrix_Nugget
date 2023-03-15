using Microsoft.Extensions.Configuration;
using System.DirectoryServices;
using System.Net;

namespace SAE.Matrix.Common.Implementations.Managers
{
    using Contracts.Managers;
    using Entities;

    public class LDAPManager : ILDAPManager
    {
		private readonly IConfiguration _configuration;

		public LDAPManager(IConfiguration configuration)
		{
			_configuration = configuration;
		}

        public ResponseBase<SearchResult> GetUserInfo(string username, string password, string[] propertiesToLoad)
        {
            ResponseBase<SearchResult> response = new ResponseBase<SearchResult>((int)HttpStatusCode.OK, null);

            try
			{
				string path = $@"{_configuration["AD:Path"]}/{_configuration["AD:DN"]}";
				string usernameWithDomain = $"{username}@{_configuration["AD:Domain"]}";
                SearchResult? searchResult = null;

                using (DirectoryEntry directoryEntry = new DirectoryEntry(path, usernameWithDomain, password))
				{
					using(DirectorySearcher directorySearcher= new DirectorySearcher(directoryEntry))
					{
						directorySearcher.PropertiesToLoad.AddRange(propertiesToLoad);
						directorySearcher.Filter = $"(sAMAccountName={username})";
						searchResult = directorySearcher.FindOne();
                    }
				}

				if(searchResult == null)
				{
					response.Code = (int)HttpStatusCode.InternalServerError;
					response.Message = $"No se encontró el usuario {username}";
                }
				else 
					response.Data = searchResult;

                return response;
            }
			catch (Exception ex)
			{
                return new ResponseBase<SearchResult>() { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message, Data = null };
            }
        }
    }
}