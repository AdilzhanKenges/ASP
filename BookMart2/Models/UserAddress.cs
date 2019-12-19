using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMart2.Models
{
    public class UserAddress
    {
        [Key]
        [ForeignKey("Users")]
        public int UserID { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        public virtual User User { get; set; }
    }
}
