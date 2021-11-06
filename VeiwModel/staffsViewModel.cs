using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Models
{
    public class staffsViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "input the required Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "input the required Phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "input the required Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "input the required field")]
        public string Address { get; set; }
        [Required(ErrorMessage = "input the required Next of kin")]
        public string NofKin { get; set; }
        [Required(ErrorMessage = "input the required Phone number")]
        public string NofKinPhone { get; set; }
        public string Relationship { get; set; }
    }


    public class staffUpdateViewModel
    {

        [Required(ErrorMessage = "Id is missing")]
        public int Id { get; set; }
        [Required(ErrorMessage = "input Password")]
        public string Password { get; set; }
      
    }

    public class StaffViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string NofKin { get; set; }
        public string NofKinPhone { get; set; }
        public string NofKinEmail { get; set; }
        public string Relationship { get; set; }


    }
}
