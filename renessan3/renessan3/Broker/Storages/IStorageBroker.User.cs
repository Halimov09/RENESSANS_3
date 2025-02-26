using renessan3.Models.Foundation;

namespace renessan3.Broker.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Users> InsertUsersAsync(Users users);
    }
}
