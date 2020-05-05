using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC.Smart.Models.Enums;

namespace MVC.Smart.Models
{
    public class Employee
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        [EmailAddress]
        public string Email { get; set; }

        
        public Gender Gender { get; set; }
        [Range(1200, 50000)]
        public int Salary { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

    }
}