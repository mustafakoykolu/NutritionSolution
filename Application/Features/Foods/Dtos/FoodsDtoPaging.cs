using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Features.Foods.Dtos
{
    public class FoodsDtoPaging : IPaginationResponse
    {
        public int PageNumber { get ; set ; }
        public int PageSize { get; set ; }
        public int TotalCount { get; set; }
        public int DataCount { get; set; }
        public object Data { get; set; }
    }
}
