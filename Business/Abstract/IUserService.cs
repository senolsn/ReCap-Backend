using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);

        IResult UserForUpdate(UserForUpdateDto userForUpdateDto);

        IResult Update(User user);
    }
}
