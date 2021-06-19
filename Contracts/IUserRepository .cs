using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    /// <summary>
    /// Interface specific for User model.
    /// Implements IRB wrapper.
    /// </summary>
    public interface IUserRepository : IRepositoryBase<User>
    {


    }
}
