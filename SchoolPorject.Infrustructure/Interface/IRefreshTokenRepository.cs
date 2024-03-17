using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Infrustructure.InfrastructureBases;

namespace SchoolProject.Infrustructure.Interface
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {

    }
}
