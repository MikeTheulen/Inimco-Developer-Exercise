using Backend.Context;
using Backend.Models;

namespace Backend.Repository
{
    public interface IUserRepository
    {
        public Task<User> Add(UserContext userContext, User user);

        public Task<User> Get(UserContext userContext, User user);

        void HowManyConstenants(string name);

        void HowManyVowels(string name);

        void JSONFormat(User user);

        void ReverseName(string name);
    }
}
