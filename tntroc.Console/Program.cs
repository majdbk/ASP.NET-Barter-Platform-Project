using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tntroc.Domain.Entities;

namespace tntroc.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            tntroc.Services.IGoodService IGS = new tntroc.Services.GoodService();
            goods goood = new goods();
            goood.accepted = Accpted.yes;
            goood.brand = "zaeaze";
            goood.date = new DateTime();
            goood.description = "lkhlkh";
            goood.id_goods = 1;
            goood.label = "label";
            goood.quantity = 45;
            goood.validity = 5;
            goood.swapperID = 1;
            goood.subCategoryID = 1;
            IGS.Add(goood);
        }
    }
}
