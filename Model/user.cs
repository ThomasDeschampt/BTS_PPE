using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("user")]
    public class user
    {
        [Key]
        public int id_user { get; set; }

        [Required]
        [StringLength(25)]
        public string pseudo_user { get; set; }

        [Required]
        [StringLength(15)]
        public string mdp_user { get; set; }
    }
}
