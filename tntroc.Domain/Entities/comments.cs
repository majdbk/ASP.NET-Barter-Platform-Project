using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tntroc.Domain.Entities
{
    [Table("comments")]
    public class comments
    {
        [Key]
        public int id_comments { get; set; }

        public string comment  { get; set; }

       /* public int forumID { get; set; }

        [ForeignKey("forumID")]
        public virtual forum forum { get; set; }*/
    }
}
