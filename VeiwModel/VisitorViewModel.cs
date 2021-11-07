using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.VeiwModel
{
    public class VisitorViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "input Email")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "input Password")]
        public string Password { get; set; }
    }
}
