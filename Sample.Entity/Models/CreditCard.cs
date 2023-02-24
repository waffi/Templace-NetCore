using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entity.Models
{
    [Table("CreditCard", Schema = "dbo")]
    public class CreditCard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CcNumber { get; set; }
        [Required]
        public string CcType { get; set; }
        [Required]
        public string CcExp { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}
