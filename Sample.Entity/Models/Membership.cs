using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entity.Models
{
    [Table("Membership", Schema = "dbo")]
    public class Membership
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Fee { get; set; }
        [Required]
        public int MinAge { get; set; }
    }
}
