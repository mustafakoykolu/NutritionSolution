using Application.Contracts.Persistence;
using Domain;
using Domain.Entity;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {
        public FoodRepository(PersistenceDbContext context) : base(context)
        {

        }

        //custom methods
    }
}
