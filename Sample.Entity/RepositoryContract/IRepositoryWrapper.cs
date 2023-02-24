using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entity.RepositoryContract
{
    public interface IRepositoryWrapper
    {
        IUserRepository Category { get; }
        IAddressRepository Product { get; }
        void Save();
    }
}
