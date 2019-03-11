using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tntroc.Domain.Entities
{
    public enum Accpted {yes,no}

    [Table("goods")]
    public class goods
    {
        public goods()
        {
            this.exchangesgoodsoffre = new List<exchange>();
            this.exchangesgoodsdemande = new List<exchange>();
        }

        [Key]
        public int id_goods { get; set; }

        public string brand  { get; set; }
        public string description { get; set; }

        public DateTime date { get; set; }
        public int validity  { get; set; }
        public int quantity { get; set; }
        public string label { get; set; }
        public Accpted accepted { get; set; }

        public int subCategoryID { get; set; }

        [ForeignKey("subCategoryID")]
        public virtual subCategory subCategory { get; set; }

        public int swapperID { get; set; }

        [ForeignKey("swapperID")]
        public virtual swapper swapper { get; set; }

        public ICollection<exchange> exchangesgoodsoffre { get; set; }
        public ICollection<exchange> exchangesgoodsdemande { get; set; }

        public String image { get; set; }

        public int score { get; set; }
    }
}
