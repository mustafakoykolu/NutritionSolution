using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserTypeRepository: GenericRepository<UserType>, IUserRepository
    {
        public UserTypeRepository(UserDatabaseContext context):base(context) 
        {
            
        }

        public Task<UserType> GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
