using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    /// <summary>
    /// Interface specific for Account model.
    /// Implements IRB wrapper.
    /// </summary>
    public interface IAccountRepository : IRepositoryBase<Account>
    {

    }
}
