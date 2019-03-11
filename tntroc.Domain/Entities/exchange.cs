using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tntroc.Domain.Entities
{
    public enum Statusexchange { pending,accepted,confirmed,canceled }


        [Table("exchange")]
        public class exchange
        {
            [Key]
            public int id_exchange { get; set; }


            public int idgoodOffre { get; set; }
            public virtual goods goodOffre { get; set; }

            public int idgooddemande { get; set; }
            public virtual goods goodDemande { get; set; }

            //public int idswap { get; set; }
            // public virtual swapper swapper { get; set; }


            public Statusexchange status { get; set; } = 0;

            public DateTime date_exchange { get; set; }

        }
}
