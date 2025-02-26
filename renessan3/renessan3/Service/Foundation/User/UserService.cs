using renessan3.Broker.Storages;
using renessan3.Models.Foundation;

namespace renessan3.Service.Foundation.User
{
    public class UserService: IuserService
    {
        private readonly IStorageBroker storageBroker;

        public UserService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Users> AddUserAsync(Users user) =>
            await this.storageBroker.InsertUsersAsync(user);
    }
}
