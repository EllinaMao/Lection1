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
    public string Message { get; set; }


    public IndexModel(ITimeService timeService)
    {
        Message = $"Текущее время: {timeService.Time}";
    }

}