using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Calc;
using System.Web.Services.Description;
using System.Web.Mvc;

namespace WebCalc.Models
{
    public class CalcViewModel
    {
        public string Result { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public List<SelectListItem> ListOperations { get; set; }

        public string Operation { get; set; }

        public CalcViewModel()
        {
            ListOperations = new List<SelectListItem>();
            var calc = new Calculator();
            var opers = calc.GetOperations();
            for(var i = 0; i < opers.Length; i++)
            {
                var item = new SelectListItem();
                item.Text = opers[i].Name;
                item.Value = opers[i].Name;
                ListOperations.Add(item);
            }
        }
    }

}