using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using tntroc.Domain.Entities;
using tntroc.Services;

namespace tntroc.WebApplication.Models
{
    public class GoodModels
    {
        public string txt { get; set; }
        public string txtSearch;
        public goods goood;
        public IEnumerable<goods> listGoods;
        IGoodService IGS = new GoodService();
        public GoodModels()
        {
            listGoods = IGS.GetAll();
            goood = new goods();
        }

    }
}