using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaneerandPeas_J110892.Data;

namespace PaneerandPeas_J110892.Pages.Admin
{
    public class CreateeModel : PageModel  // Use CreateeModel instead of CreateModel
    {
        private readonly ApplicationDbContext _context;

        public CreateeModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodItem FoodItem { get; set; }

        // Handle the form submission to create a new dish
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Reload the page if validation fails
            }

            // Add the new dish to the database
            _context.FoodItem.Add(FoodItem);
            _context.SaveChanges();

            // Redirect to the Menu page after creation
            return RedirectToPage("/Menu");
        }
    }
}
