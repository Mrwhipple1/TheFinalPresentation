using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class IngredientsSqlDAO : IIngredientsDAO
    {
        private readonly string connectionString;

        private string sqlAddIngredient = "INSERT INTO ingredients (ingredient_name, user_id) " +
            " VALUES (@ingredient_name, @user_id); ";

        private string sqlGetAllIngredients = "SELECT ingredient_name FROM ingredients WHERE user_id = @user_id";

        public IngredientsSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        public bool AddIngredient(Ingredient ingredient)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlAddIngredient, conn);


                    cmd.Parameters.AddWithValue("@ingredient_name", ingredient.IngredientName.ToLower().Trim());
                    cmd.Parameters.AddWithValue("@user_id", ingredient.UserId);


                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        public List<Ingredient> GetAllIngredients(int userId)
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAllIngredients, conn);

                    cmd.Parameters.AddWithValue("@user_id", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Ingredient ingredient = new Ingredient();

                        ingredient.IngredientName = Convert.ToString(reader["ingredient_name"]);

                        ingredients.Add(ingredient);
                    }
                }
            }
            catch (Exception ex)
            {
                ingredients = new List<Ingredient>();
            }
            return ingredients;
        }
    }
}
