using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PaneerandPeas_J110892.Data;
using System.Collections.Generic;
using System.Linq;

public class MenuModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public MenuModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<FoodItem> FoodItems { get; set; }

    public void OnGet()
    {
       
        FoodItems = _context.FoodItem
            .AsNoTracking() 
            .OrderByDescending(f => f.Id) 
            .ToList();
    }
}
