using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaneerandPeas_J110892.Data;
using System.Linq;

namespace PaneerandPeas_J110892.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodItem FoodItem { get; set; }

        public IActionResult OnGet(int? id)
        {
            

            FoodItem = _context.FoodItem.FirstOrDefault(f => f.Id == id);

            

            return Page();
        }

        public IActionResult OnPost()
        {
           

            var existingItem = _context.FoodItem.FirstOrDefault(f => f.Id == FoodItem.Id);
            if (existingItem != null)
            {
                existingItem.Name = FoodItem.Name;
                existingItem.Description = FoodItem.Description;
                existingItem.Price = FoodItem.Price;

                _context.SaveChanges();
            }

            return RedirectToPage("/Menu");
        }
    }
}
