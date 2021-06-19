using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    /// <summary>
    /// RepositoryWrapper class to acces all model-repositories in api from each controller.
    /// </summary>
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IUserRepository _owner;
        private IAccountRepository _account;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_owner == null)
                {
                    _owner = new UserRepository(_repoContext);
                }
                return _owner;
            }
        }
        public IAccountRepository Account
        { 
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }
                return _account;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
