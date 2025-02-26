using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using renessan3.Models.Foundation;
using System.Collections.Generic;

namespace renessan3.Broker.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Users> User { get; set; }

        public async ValueTask<Users> InsertUsersAsync(Users users)
        {
            EntityEntry<Users> userEntityEntry =
                await this.User.AddAsync(users);

            await this.SaveChangesAsync();

            return userEntityEntry.Entity;
        }
    }
}
