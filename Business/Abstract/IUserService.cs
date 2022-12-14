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
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);

        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult Update(User user);

        IResult Delete(User user);
    }
}
