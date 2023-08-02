using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieWebsiteDemo.Core.Models;

namespace MovieWebsiteDemo.Repository.DataAccess.Seeds
{
    internal class DirectorSeed : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasData(
                new Director { Id = 1, DirectorName = "Jon Favreau", DirectorPhoto = "-", DirectorBiography = "Jonathan Kolia Favreau, kısaca Jon Favreau, Amerikalı oyuncu ve yönetmendir. En iyi Şef filmi ve Iron Man serisi dahil olmak üzere Marvel Sinematik Evreni'nde canlandırdığı Happy karakteri ile bilinir. Ayrıca yönetmenliğini yaptığı filmler arasında Iron Man ve Iron Man 2 bulunur. Aynı zamanda ünlü komedi dizisi Friends de Monica'nını milyoner erkek arkadaşı Pete Becker'ı canlandırmıştır." }

                );
        }
    }
}
