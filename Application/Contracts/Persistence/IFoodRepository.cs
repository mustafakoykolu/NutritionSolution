using Domain;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IFoodRepository : IGenericRepository<Food>
    {
        //custom methods
        Task<List<Food>> SearchByName(string userName, int pageNumber, int pageSize);
        Task<int> SearchByNameCount(string userName, int pageNumber, int pageSize);
        Task<Food> GetByIdAsync(int id);

    }
}
