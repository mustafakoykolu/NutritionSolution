using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class MeasureUnit:BaseEntity
    {
        public string Name { get; set; }
        public string NameTr { get; set; }
        public string Abbreviation { get; set; }
    }
}
