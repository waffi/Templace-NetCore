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

        private IUserRepository _category;

        private IAddressRepository _product;

        public IUserRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new UserRepository(_databaseContext);
                }
                return _category;
            }
        }

        public IAddressRepository Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new AddressRepository(_databaseContext);
                }
                return _product;
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
