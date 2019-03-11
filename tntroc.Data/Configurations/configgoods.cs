using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tntroc.Domain.Entities;

namespace tntroc.Data.Configurations
{
    public class configgoods : EntityTypeConfiguration<goods>
    {
        public configgoods()
        {
            HasRequired(c => c.subCategory).WithMany(t => t.goodss).HasForeignKey(fk => fk.subCategoryID);
            HasRequired(c => c.swapper).WithMany(t => t.goods).HasForeignKey(fk => fk.swapperID);       
        }
    }
}
