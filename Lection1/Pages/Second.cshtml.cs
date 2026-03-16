using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lection1.Pages
{
    public class ExchangeModel : PageModel
    {
        public string Message { get; set; }
        private readonly decimal currentRate = 38.1m;

        public void OnGet()
        {
            Message = "Enter the amount";
        }
        public void OnPost(int? sum)
        {
            if (sum == null || sum < 1000)
            {
                Message = "An incorrect amount was transmitted. Repeat the entry.";
            }
            else
            {
                decimal result = sum.Value / currentRate;
                Message = $"In exchange {sum} of hryvnias you'll get {result.ToString("F2")} dollars.";
            }
        }
    }
}

