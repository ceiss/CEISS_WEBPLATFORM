using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    [Table("CAREERS")]
    public class Career
    {
        [Key]
        public int CareerId { get; set; }
        [StringLength(6)]
        public string CareerCode { get; set; }
        [StringLength(30)]
        public string CareerName { get; set; }
        public IEnumerable<Student> CareerStudents { get; set; }

    }
}
