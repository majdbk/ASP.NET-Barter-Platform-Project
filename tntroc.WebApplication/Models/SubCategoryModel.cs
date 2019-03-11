using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using tntroc.Domain.Entities;

namespace tntroc.WebApplication.Models
{
    public class SubCategoryModel
    {
        public SubCategoryModel()
        {
            this.goodss = new List<GoodsModels>();
        }

        [Key]
        [Column("id_subCategory")]
        public int id_subCategory { get; set; }

        [Column("name")]
        public string name { get; set; }

        [Column("description")]
        public string description { get; set; }


        

        [Column("categoryID")]
        public int categoryID { get; set; }

        [ForeignKey("categoryID")]
        public virtual CategoryModels category { get; set; }

        public ICollection<GoodsModels> goodss { get; set; }


        public static implicit operator SubCategoryModel(subCategory sub)
        {
            return new SubCategoryModel
            {
                categoryID = sub.categoryID,
                description = sub.description,
                name = sub.name,
                id_subCategory = sub.id_subCategory,
                category = sub.category
               // goodss=sub.goodss
              
            };
        }

        public static implicit operator subCategory(SubCategoryModel sb)
        {
            return new subCategory
            {
                id_subCategory = sb.id_subCategory,
                description = sb.description,
                name = sb.name,
                categoryID= sb.categoryID,
                category = sb.category
               // goodss=sb.goodss
            };


        }

    }
}