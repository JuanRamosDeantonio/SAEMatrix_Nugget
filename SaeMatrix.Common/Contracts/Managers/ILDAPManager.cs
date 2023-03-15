using System.DirectoryServices;

namespace SAE.Matrix.Common.Contracts.Managers
{
    using Entities;

    public interface ILDAPManager
    {
        ResponseBase<SearchResult> GetUserInfo(string username, string password, string[] propertiesToLoad);
    }
}