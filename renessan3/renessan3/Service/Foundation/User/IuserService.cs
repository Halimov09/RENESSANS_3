using renessan3.Models.Foundation;

namespace renessan3.Service.Foundation.User
{
    public interface IuserService
    {
        ValueTask<Users> AddUserAsync(Users user);
    }
}
