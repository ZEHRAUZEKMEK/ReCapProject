using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
