using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetByEmailWithResult(string email);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IDataResult<User> GetById(int userId);
        void Add(User user);
        IResult Update(User user);
        IResult UpdateUserNames(User user);
        IResult Delete(User user);
    }
}
