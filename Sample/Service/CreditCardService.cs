
using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;

namespace Sample.Service
{
    public class CreditCardService
    {
        private readonly ILogger<CreditCardService> _logger;

        private IRepositoryWrapper _repository;

        public CreditCardService(ILogger<CreditCardService> logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public List<CreditCard> FindAll()
        {
            return _repository.CreditCard.FindAll().ToList();
        }

        public CreditCard FindById(int id)
        {
            return _repository.CreditCard.Find(x => x.Id == id).FirstOrDefault();
        }

        public List<CreditCard> FindByUserId(int userId)
        {
            return _repository.CreditCard.Find(x => x.UserId == userId).ToList();
        }

        public CreditCard Create(int userId, CreditCard creditCard)
        {
            creditCard.UserId = userId;
            _repository.CreditCard.Create(creditCard);
            _repository.Save();

            return creditCard;
        }

        public CreditCard Update(int id, CreditCard creditCard)
        {
            var entity = _repository.CreditCard.Find(x => x.Id == id).FirstOrDefault();
            entity.CcNumber = creditCard.CcNumber;
            entity.CcType = creditCard.CcType;
            entity.CcExp = creditCard.CcExp;
            entity.DateOfBirth = creditCard.DateOfBirth;

            _repository.CreditCard.Update(entity);
            _repository.Save();

            return entity;
        }

        public void Delete(int id)
        {
            var entity = _repository.CreditCard.Find(x => x.Id == id).FirstOrDefault();

            _repository.CreditCard.Delete(entity);
            _repository.Save();
        }
    }
}
