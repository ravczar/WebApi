using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IUserRepository _owner;
        private IAccountRepository _account;

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
