using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tntroc.Domain.Entities
{
    public enum Status { pending, dinished, farud }

    [Table("claim")]
    public class claim
    {
        [Key]
        public int id_claim { get; set; }
        public string cause  { get; set; }
        public string description  { get; set; }
        public DateTime date { get; set; }
        public Status status { get; set; }

        
    }
}
