using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entity.RepositoryContract
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IAddressRepository Address { get; }
        ICreditCardRepository CreditCard { get; }
        IMembershipRepository Membership { get; }
        void Save();
    }
}
