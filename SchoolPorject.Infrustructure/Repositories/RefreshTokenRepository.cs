using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Infrustructure.Domain;
using SchoolProject.Infrustructure.InfrastructureBases;
using SchoolProject.Infrustructure.Interface;

namespace SchoolProject.Infrustructure.Repositories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        private DbSet<UserRefreshToken> userRefreshToken;
        public RefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            userRefreshToken = dbContext.Set<UserRefreshToken>();
        }
    }
}
