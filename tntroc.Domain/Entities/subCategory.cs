using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tntroc.Domain.Entities
{
    [Table("subCategory")]
    public class subCategory
    {
        public subCategory()
        {
            this.goodss = new List<goods>();
        }

        [Key]
        [Column("id_subCategory")]
        public int id_subCategory { get; set; }

        [Column("name")]
        public string name  { get; set; }

        [Column("description")]
        public string description { get; set; }

        [Column("categoryID")]
        public int categoryID { get; set; }

        [ForeignKey("categoryID")]
        public virtual category category { get; set; }

        public ICollection<goods> goodss { get; set; }

    }
}
