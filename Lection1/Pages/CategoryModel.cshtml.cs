using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Lection1.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ToDoService _service;

        public CategoryModel(ToDoService service)
        {
            _service = service;
        }

        public ActionResult OnGet(string category)
        {
            Items = _service.GetItemsForCategory(category);
            return Page();
        }
        public List<ToDoListModel> Items { get; set; }
    }

    public class ToDoService
    {
        public List<ToDoListModel> GetItemsForCategory(string category)
        {
            return new List<ToDoListModel>()
            {
                //...
            };
        }
    }
    public class ToDoListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

