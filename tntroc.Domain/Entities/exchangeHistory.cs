using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tntroc.Domain.Entities
{
    [Table("exchangeHistory")]
    public class exchangeHistory
    {
        [Key]
        public int id_exchange { get; set; }

        public int id_annonceur { get; set; }
        public int id_proposeur { get; set; }
        public int id_goodsan { get; set; }
        public int id_goodsprop { get; set; }

    }
}
