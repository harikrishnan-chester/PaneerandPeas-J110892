using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaneerandPeas_J110892.Data;

namespace PaneerandPeas_J110892.Pages
{
    public class DeleteModel : PageModel
    {
		private readonly ApplicationDbContext _context;

		public DeleteModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult OnPost(int id)
		{
			var foodItem = _context.FoodItem.FirstOrDefault(f => f.Id == id);
			if (foodItem != null)
			{
				_context.FoodItem.Remove(foodItem);
				_context.SaveChanges();
			}
			return RedirectToPage("/Menu");
		}
	}
}
