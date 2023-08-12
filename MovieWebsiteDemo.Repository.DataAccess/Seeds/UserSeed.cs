using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Repository.DataAccess.Seeds
{
    internal class UserSeed : IEntityTypeConfiguration<UserApp>
    {
        public void Configure(EntityTypeBuilder<UserApp> builder)
        {
            
        }
    }
}
