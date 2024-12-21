using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPaginationRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
