using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Calc;
using System.Web.Mvc;
using WebCalc.Models;
using WebCalc.db.Repository;
using WebCalc.db.Models;

namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {
        private ICalcHistoryRepository repository { get; set; }

        public CalcController()
        {
            repository = new CalcHistoryRepository();
        }

        public ActionResult Index()
        {
            var model = new CalcViewModel();
            model.ListOperations = GetOperations();
            return View("Index", model);
        }

        public ActionResult Calc(CalcViewModel model)
        {
            var calc = new Calculator();
            var method = typeof(Calculator).GetMethod(model.Operation);

            var x = model.X;
            var y = model.Y;
            var opers = Calculator.GetOperations();
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
            #region Добавление в историю

            var ch = new CalcHistory();
            ch.Operation = model.Operation;
            ch.Result = Convert.ToDouble(model.Result);
            ch.X = model.X;
            ch.Y = model.Y;

            #endregion

            repository.Add(ch);

            model.ListOperations = GetOperations(model.Operation);

            return View("Index", model);
        }

        private IList<SelectListItem> GetOperations(string selected = "")
        {
            var listOperations = new List<SelectListItem>();

            var opers = Calculator.GetOperations();

            foreach (var oper in opers)
            {
                var item = new SelectListItem();
                item.Text = oper.Name;
                item.Value = oper.Name;

                item.Selected = !string.IsNullOrWhiteSpace(selected) && item.Text == selected;

                listOperations.Add(item);
            }
            return listOperations;
        }

        public ActionResult History()
        {
            var opers = GetOperations();
            ViewData["Operations"] = opers.ToList();
            
            // присваиваем значение в контроллере
            var history = repository.GetList();
            return View(history);
        }

        [HttpPost]
        public ActionResult History(string Operations)
        {
            var opers = GetOperations();
            ViewData["Operations"] = opers.ToList();
            var sortedHistory = repository.Find(Operations);
            return View(sortedHistory);
        }
    }
}