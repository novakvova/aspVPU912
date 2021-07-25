using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Web.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }

    public class SearchCarIndexModel
    {
        public string Mark { get; set; }
    }

    public class CarCreateViewModel
    {
        [Display(Name ="Марка")]
        public string Mark { get; set; }
        [Display(Name ="Модель")]
        public string Model { get; set; }
        [Display(Name ="Рік")]
        public int Year { get; set; }
    }
}
