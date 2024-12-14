using Microsoft.AspNetCore.Mvc.RazorPages;
using PaneerandPeas_J110892.Data;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
        FoodItems = _context.FoodItems
            .FromSqlRaw("SELECT Id, Name, Description, Price FROM FoodItem")
            .ToList();
    }
}
