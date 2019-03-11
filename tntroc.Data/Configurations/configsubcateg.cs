using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tntroc.Domain.Entities;

namespace tntroc.Data.Configurations
{
    public class configsubcateg : EntityTypeConfiguration<subCategory>
    {
  
        public configsubcateg()
        {
            HasRequired(t=>t.category).WithMany(t => t.subCategorys).HasForeignKey(fk => fk.categoryID);
        }
        
    }
}
