using renessan3.Broker.Storages;
using renessan3.Models.Foundation;
using renessan3.Service.Foundation.Telegram;

namespace renessan3.Service.Foundation.User
{
    public class UserService : IuserService
    {
        private readonly IStorageBroker storageBroker;
        private readonly TelegramService telegramService; // 🔹 Telegram xizmati

        public UserService(IStorageBroker storageBroker, TelegramService telegramService)
        {
            this.storageBroker = storageBroker;
            this.telegramService = telegramService;
        }

        public async ValueTask<Users> AddUserAsync(Users user)
        {
            var createdUser = await this.storageBroker.InsertUsersAsync(user);

            // 🔹 Telegramga xabar yuborish
            string message = $@"
            🆕 Yangi foydalanuvchi qo‘shildi!
            🆔 ID: {createdUser.Id}
            👤 Ism: {createdUser.Name}
            📞 Raqam: {createdUser.Numbers}
            📚 Kurs: {createdUser.Course}";

            await telegramService.SendMessageAsync("-1002406594366", message);

            return createdUser;
        }
    }
}
