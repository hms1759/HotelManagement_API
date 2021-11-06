using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Models
{
    public class Staffs
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
