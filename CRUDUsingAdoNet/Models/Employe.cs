using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUsingAdoNet.Models
{
    [Table("Employee2")]
    public class Employe
    {
        [Key]
        [ScaffoldColumn(false)]
        public string emp_code{ get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string emp_Name { get; set; }

        [Required(ErrorMessage = "DepartmentName is required")]
        public string emp_dept { get; set; }
        
    }
}




