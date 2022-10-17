using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUDUsingAdoNet.Models
{
    public class Department
    {
        [Key]
        [ScaffoldColumn(false)]
        public string dept_code{ get; set; }
        [Required(ErrorMessage="name is required")]
        public string? dept_name{ get; set; }
        
      
    }

}
