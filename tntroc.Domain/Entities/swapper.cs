using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tntroc.Domain.Entities
{
    public enum Sex { M, F }

    public class swapper
    {
        public swapper()
        {
            this.goods= new List<goods>();
            this.exchangeswaps = new List<exchange>();
            //this.claims = new List<claim>();
        }

        [Key]
        public int id_swapper { get; set; }

        public string firstname { get; set; }
        public DateTime dateofbirth  { get; set; }
        public long Phonenumber { get; set; }
        public string email { get; set; }
        public string adress { get; set; }
        public string state { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Sex sex { get; set; }
        public string status { get; set; }
        public string lastname { get; set; }
        public string imgPath { get; set; }

        public ICollection<goods> goods { get; set; }
        public ICollection<exchange> exchangeswaps { get; set; }
       // public ICollection<claim> claims { get; set; }
    }
}
