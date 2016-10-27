using System.Collections.Generic;
using Calc;
using System.Web.Mvc;

namespace WebCalc.Models
{
    public class CalcViewModel
    {
        public string Result { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public string Operation { get; set; }

        public IList<SelectListItem> ListOperations { get; set; }

        public CalcViewModel()
        {
            ListOperations = new List<SelectListItem>();
        }

        public CalcViewModel(string selected = "")
        {
            ListOperations = new List<SelectListItem>();

            var opers = Calculator.GetOperations();

            
        }
    }

}