using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate);
        IDataResult<User> GetByMail(string userMail);

        IDataResult<UserDetailDto> GetUserDetailByMail(string userMail);

    }
}
