using Application.Common.Dtos;
using Application.Features.Meals.Dtos;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Meals.Queries
{
    public class GetMealsQuery : IRequest<DataDtoPaging>, IPaginationRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
