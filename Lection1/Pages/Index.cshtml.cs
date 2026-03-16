using Lection1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


/*
* Разработайте веб-страницу с использованием ASP.NET Core Razor Pages, которая будет представлять простой калькулятор для выполнения математических операций.
Разместите форму на странице, в которой пользователь может вводить числа и выбирать математическую операцию (сложение, вычитание, умножение, деление).
При отправке формы обработайте введенные пользователем данные на сервере с использованием синтаксиса Razor на странице cshtml.
Выведите результат операции на страницу для пользователя.*


 */
public class IndexModel : PageModel

{
    [BindProperty]
    public double Number1 { get; set; }

    [BindProperty]
    public double Number2 { get; set; }

    [BindProperty]
    public Operation SelectedOperation { get; set; }

    public string Result { get; set; }

    public Operation[] Operations { get; set; }

    public void OnGet()
    {
        Operations = (Operation[])Enum.GetValues(typeof(Operation));
    }

    public void OnPost()
    {
        Operations = (Operation[])Enum.GetValues(typeof(Operation));

        try
        {
            double result = SelectedOperation switch
            {
                Operation.Add => Math.Round(Number1 + Number2, 10),
                Operation.Subtract => Math.Round(Number1 - Number2, 10),
                Operation.Multiply => Math.Round(Number1 * Number2, 10),
                Operation.Divide => Number2 != 0 ? Math.Round(Number1 / Number2, 10) : throw new DivideByZeroException(),
                Operation.Power => Math.Pow(Number1, Number2),
                Operation.SquareRoot => Number1 >= 0 ? Math.Sqrt(Number1) : throw new InvalidOperationException("Корень из отрицательного числа"),
                Operation.Percent => Math.Round(Number1 % Number2, 10),

                _ => throw new InvalidOperationException("Неверная операция")
            };

            string symbol = SelectedOperation switch
            {
                Operation.Add => "+",
                Operation.Subtract => "-",
                Operation.Multiply => "*",
                Operation.Divide => "/",
                Operation.Power => "^",
                Operation.SquareRoot => "√",
                Operation.Percent => "%",

                _ => ""
            };

            Result = SelectedOperation == Operation.SquareRoot 
                ? $"{symbol}({Number1}) = {result}"
                : $"{Number1} {symbol} {Number2} = {result}";
        }
        catch (DivideByZeroException)
        {
            Result = "Ошибка: деление на ноль невозможно";
        }
        catch (Exception ex)
        {
            Result = $"Ошибка: {ex.Message}";
        }
    }
}
public enum Operation
{
    [Display(Name = "+")]
    Add,

    [Display(Name = "−")]
    Subtract,

    [Display(Name = "×")]
    Multiply,

    [Display(Name = "÷")]
    Divide,

    [Display(Name = "xʸ")]
    Power,

    [Display(Name = "√")]
    SquareRoot,

    [Display(Name = "%")]
    Percent,


}