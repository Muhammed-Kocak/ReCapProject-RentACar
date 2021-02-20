using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        DataResult<List<User>> GetAll();
        DataResult<User> GetById(int id);
        Result Add(User user);
        Result Delete(User user);
        Result Update(User user);
    }
}
