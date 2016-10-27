using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calc;

namespace WebCalc.db.Models
{   /// <summary>
    /// Историческое событие
    /// </summary>
    public class CalcHistory
    {
        public int Id { get; set; }

        public double? Result {get; set;}

        public double X { get; set; }

        public double Y { get; set; }
        /// <summary>
        /// Математическое действие
        /// </summary>
        public string Operation { get; set; }

        public IList<SelectListItem> ListOperations { get; set; }

        public CalcHistory()
        {
            ListOperations = new List<SelectListItem>();
        }

        public CalcHistory(string selected = "")
        {
            ListOperations = new List<SelectListItem>();
            var opers = Calculator.GetOperations();
        }

        public DateTime CreationDate { get; set; }
    }
}