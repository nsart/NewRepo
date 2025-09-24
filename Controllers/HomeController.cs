using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using HW3_Task1.Models;

namespace HW3_Task1.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View(new CalcModel());
        }

        [HttpPost]
        public IActionResult ProcessForm(CalcModel model, string actionButton)
        {
            var Num1String = HttpContext.Request.Form["Num1"];
            var Num2String = HttpContext.Request.Form["Num2"];
            // перетворення чисел до єдиного вигляду у випадку введення крапки, як розділового знаку
            if (decimal.TryParse( Num1String, NumberStyles.Float,CultureInfo.InvariantCulture,out decimal parsedNum1))
            {
                model.Num1 = parsedNum1;
            }
            if (decimal.TryParse(Num2String, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal parsedNum2))
            {
                model.Num2 = parsedNum2;
            }

            if (model.Num1.HasValue && model.Num2.HasValue)
            {
                switch (actionButton)
                {
                    case "+":
                        model.Result = model.Num1.Value + model.Num2.Value;
                        model.OperationName = "додавання";
                        break;
                    case "-":
                        model.Result = model.Num1.Value - model.Num2.Value;
                        model.OperationName = "віднімання";
                        break;
                    case "/":
                        model.Result = model.Num1.Value / model.Num2.Value;
                        model.OperationName = "ділення";
                        break;
                    case "*":
                        model.Result = model.Num1.Value * model.Num2.Value;
                        model.OperationName = "множення";
                        break;
                    default:
                        model.Result = null;
                        model.OperationName = "операції не визначено";
                        break;
                }
            }
            return View("Index", model);
        }
    }
}
