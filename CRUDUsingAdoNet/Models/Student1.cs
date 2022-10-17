using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUsingAdoNet.Models
{
    public class Student1
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Branch name is required")]
        public string? Branch { get; set; }
        [Required(ErrorMessage = "Percentage is required")]
        public int? Percentage { get; set; }
    }
}
