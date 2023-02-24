
using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;

namespace Sample.Service
{
    public class MembershipService
    {
        private readonly ILogger<MembershipService> _logger;

        private IRepositoryWrapper _repository;

        public MembershipService(ILogger<MembershipService> logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public List<Membership> FindAll()
        {
            return _repository.Membership.FindAll().ToList();
        }

        public Membership FindById(int Id)
        {
            return _repository.Membership.Find(x => x.Id == Id).FirstOrDefault();
        }
    }
}
