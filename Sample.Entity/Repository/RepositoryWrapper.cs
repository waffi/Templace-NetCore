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

        private ICategoryRepository _category;

        private IProductRepository _product;

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_databaseContext);
                }
                return _category;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_databaseContext);
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
