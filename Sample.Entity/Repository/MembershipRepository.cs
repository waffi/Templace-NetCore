using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entity.Repository
{
    public class MembershipRepository : RepositoryBase<Membership>, IMembershipRepository
    {
        public MembershipRepository(DatabaseContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
