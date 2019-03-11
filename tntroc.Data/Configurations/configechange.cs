using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tntroc.Domain.Entities;

namespace tntroc.Data.Configurations
{
    public class configechange : EntityTypeConfiguration<exchange>
    {
        public configechange()
        {
            HasRequired(p => p.goodOffre).WithMany(b => b.exchangesgoodsoffre).HasForeignKey(h => h.idgoodOffre);
            HasRequired(p => p.goodDemande).WithMany(c => c.exchangesgoodsdemande).HasForeignKey(c => c.idgooddemande);
        }
    }
}
