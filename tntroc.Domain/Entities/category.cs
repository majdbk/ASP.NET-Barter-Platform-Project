using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tntroc.Domain.Entities
{
    [Table("category")]
    public class category
    {
        public category()
        {
            this.subCategorys= new List<subCategory>();
        }

        [Key]
        [Column("id_category")]
        public int id_category { get; set; }

        [Column("name")]
        public string name { get; set; }

        public ICollection<subCategory> subCategorys { get; set; }
    }
}
