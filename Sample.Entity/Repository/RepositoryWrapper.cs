using Sample.Entity.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entity.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _databaseContext;

        private IUserRepository _user;

        private IAddressRepository _address;

        private ICreditCardRepository _creditCard;

        private IMembershipRepository _membership;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_databaseContext);
                }
                return _user;
            }
        }

        public IAddressRepository Address
        {
            get
            {
                if (_address == null)
                {
                    _address = new AddressRepository(_databaseContext);
                }
                return _address;
            }
        }

        public ICreditCardRepository CreditCard
        {
            get
            {
                if (_creditCard == null)
                {
                    _creditCard = new CreditCardRepository(_databaseContext);
                }
                return _creditCard;
            }
        }

        public IMembershipRepository Membership
        {
            get
            {
                if (_membership == null)
                {
                    _membership = new MembershipRepository(_databaseContext);
                }
                return _membership;
            }
        }

        public RepositoryWrapper(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }
    }
}
