using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tntroc.Domain.Entities;
using tntroc.ServicesPattern;

namespace tntroc.Services
{
    public interface IGoodService : IService<goods>
    {
         IEnumerable<goods> searchByScore();
        category mostRatedCategory();
    }
}
