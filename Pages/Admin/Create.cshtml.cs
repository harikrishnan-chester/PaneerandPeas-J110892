using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaneerandPeas_J110892.Data;

namespace PaneerandPeas_J110892.Pages
{
    public class AdminModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodItem NewFoodItem { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FoodItem.Add(NewFoodItem);
            _context.SaveChanges();
            return RedirectToPage("/Menu");
        }
    }
}
