using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Calc;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {
        public ActionResult Index()
        {
            var model = new CalcViewModel();
            
            return View(model);
        }

        public ActionResult Calc(CalcViewModel model)
        {
            var calc = new Calculator();
            var method = typeof(Calculator).GetMethod(model.Operation);

            var x = model.X;
            var y = model.Y;
            var opers = calc.GetOperations();
            var args = new object[] { x, y };
            if (opers.FirstOrDefault(a => a.Name == model.Operation).ParameterCount == 1)
            {
                args = new object[] { x };
            }

            try
            {
                model.Result = method.Invoke(calc, args).ToString();
            }
            catch (Exception ex)
            {
                model.Result = ex.Message;
            }
            return View("Index", model);
        }
    }
}