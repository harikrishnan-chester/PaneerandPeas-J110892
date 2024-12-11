using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace PaneerandPeas_J110892.Pages
{
    public class MenuModel : PageModel
    {
        public List<menu> listMenu = new List<menu>();

        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=hari;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM menu";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            listMenu.Clear();

                            while (reader.Read())
                            {
                                menu menul = new menu
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Description = reader.GetString(reader.GetOrdinal("Description")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Price"))
                                };

                                listMenu.Add(menul);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }
    }

    public class menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
