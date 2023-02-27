using Backend.Context;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> Get(UserContext userContext, User user)
        {
            var temp = await userContext.Users.FirstOrDefaultAsync(x => 
                ($"{x.FirstName} {x.LastName}".ToLower()).Equals(
                    ($"{user.FirstName} {user.LastName}".ToLower())
                ));
            return temp ?? user;
        }

        public async Task<User> Add(UserContext userContext, User user)
        {
            await userContext.Users.AddAsync(user);
            await userContext.SaveChangesAsync();

            return user;
        }

        private readonly string[] vowels = new string[] { "a", "e", "i", "o", "u", "y" };

        public void HowManyVowels(string name)
        {
            int count = 0;

            foreach (var character in name)
                if (vowels.Contains(character.ToString().ToLower()) && character.ToString() != " ")
                    count++;

            Console.WriteLine($"The number of VOWELS: {count}");
        }

        public void HowManyConstenants(string name)
        {
            int count = 0;

            foreach (var character in name)
                if (!vowels.Contains(character.ToString().ToLower()) && character.ToString() != " ")
                    count++;

            Console.WriteLine($"The number of CONSTENANTS: {count}");
        }

        public void ReverseName(string name)
        {
            char[] array = name.ToCharArray();
            Array.Reverse(array);
            Console.WriteLine($"The reverse version of the firstname and lastname: {new string(array)}");
        }

        public void JSONFormat(User user)
        {
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            Console.WriteLine($"The JSON format of the entire object: ");
            Console.WriteLine(json);
        }
    }
}
