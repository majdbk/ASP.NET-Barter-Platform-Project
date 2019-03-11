using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tntroc.Domain.Entities
{
    [Table("forum")]
    public class forum
    {
      /*  public forum()
        {
            this.commentss = new List<comments>();
        }
        */
        [Key]
        public int id_forum { get; set; }
        public string subject { get; set; }
        public DateTime date { get; set; }


       // public ICollection<comments> commentss { get; set; }
    }
}
