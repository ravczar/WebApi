

namespace Contracts
{
    /// <summary>
    /// If controller needs data about may models he would have to instantiate all User/account repositories.
    /// To ger limit instantiation of repos, create this RepoWrapper, that collects all models repo interfaces and includes Save method.
    /// </summary>
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IAccountRepository Account { get; }
        void Save();
    }
}
