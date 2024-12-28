using Application.Common.Dtos;
using Application.Features.Foods.Dtos;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Foods.Queries
{
    public class SearchFoodQuery : IRequest<DataDtoPaging>, IPaginationRequest
    {
        public string FoodName { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
