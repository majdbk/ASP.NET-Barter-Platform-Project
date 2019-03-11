using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using tntroc.Domain.Entities;

namespace tntroc.WebApplication.Models
{
    public class CategoryModels
    {
       

        [Key]
        [Column("id_category")]
        public int id_category { get; set; }

        [Column("name")]
        public string name { get; set; }

        public ICollection<SubCategoryModel> subCategorys { get; set; }

        public static implicit operator CategoryModels(category sub)
        {
            return new CategoryModels
            {
                id_category = sub.id_category,
                name = sub.name,
                //subCategorys=sub.subCategorys

            };
        }

        public static implicit operator category(CategoryModels sb)
        {
            return new category
            {
                id_category = sb.id_category,
                // subCategorys = sb.subCategorys,
                name = sb.name,

            };


        }
    }
}