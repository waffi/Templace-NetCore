using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entity.Repository
{
    public class CreditCardRepository : RepositoryBase<CreditCard>, ICreditCardRepository
    {
        public CreditCardRepository(DatabaseContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
