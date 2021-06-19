using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public IUserRepository User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IAccountRepository Account { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
