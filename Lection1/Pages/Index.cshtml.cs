using Lection1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


/*
 Создайте метод, возводящий в степень число. Отобразите результат метода.
Весь код выполняйте только на странице Razor Page - .cshtml.
 
 */
public class IndexModel : PageModel

{

    List<Person> people;

    public Person Person { get; set; }

    public IndexModel()

    {

        people = new List<Person>()

            {

                new Person{ Name="Tom", Age=23},

                new Person {Name = "Sam", Age=25},

                new Person {Name="Bob", Age=23},

                new Person{Name="Tim", Age=25}

            };

    }

    public IActionResult OnGet(string name)

    {

        Person = people.FirstOrDefault(p => p.Name == name);

        if (Person == null)

        {

            return NotFound("User not found");

        }

        else

        {

            return Page();

        }

    }

}
