using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Nutrient:BaseEntity
    {
        public int Id { get; set; } 
        public string Number { get; set; }
        public string Name { get; set; }
        public string NameTr { get; set; }
        public int Rank { get; set; }
        public string UnitName { get; set; }
    }
}
