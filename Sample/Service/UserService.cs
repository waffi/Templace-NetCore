
using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;

namespace Sample.Service
{
    public class UserService
    {
        private readonly ILogger<UserService> _logger;

        private IRepositoryWrapper _repository;

        public UserService(ILogger<UserService> logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public List<User> FindAll()
        {
            return _repository.User.FindAll().ToList();
        }

        public User FindById(int id)
        {
            return _repository.User.Find(x => x.Id == id).FirstOrDefault();
        }

        public User Create(User user)
        {
            _repository.User.Create(user);
            _repository.Save();

            return user;
        }

        public User Update(int id, User user)
        {
            var entity = _repository.User.Find(x => x.Id == id).FirstOrDefault();
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Email = user.Email;
            entity.TermCondition = user.TermCondition;
            entity.Password = user.Password;
            entity.DateOfBirth = user.DateOfBirth;
            entity.Gender = user.Gender;

            _repository.User.Update(entity);
            _repository.Save();

            return entity;
        }

        public void Delete(int id)
        {
            var entity = _repository.User.Find(x => x.Id == id).FirstOrDefault();

            _repository.User.Delete(entity);
            _repository.Save();
        }
    }
}
