using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }= DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime DateModified { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
