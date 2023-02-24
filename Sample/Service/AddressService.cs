
using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;

namespace Sample.Service
{
    public class AddressService
    {
        private readonly ILogger<AddressService> _logger;

        private IRepositoryWrapper _repository;

        public AddressService(ILogger<AddressService> logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public List<Address> FindAll()
        {
            return _repository.Address.FindAll().ToList();
        }

        public Address FindById(int Id)
        {
            return _repository.Address.Find(x => x.Id == Id).FirstOrDefault();
        }

        public Address Create(int userId, Address address)
        {
            address.UserId = userId;
            _repository.Address.Create(address);
            _repository.Save();

            return address;
        }

        public Address Update(int id, Address address)
        {
            var entity = _repository.Address.Find(x => x.Id == id).FirstOrDefault();
            entity.Description = address.Description;

            _repository.Address.Update(entity);
            _repository.Save();

            return entity;
        }

        public void Delete(int id)
        {
            var entity = _repository.Address.Find(x => x.Id == id).FirstOrDefault();

            _repository.Address.Delete(entity);
            _repository.Save();
        }
    }
}
